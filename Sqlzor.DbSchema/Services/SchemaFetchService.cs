using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.DbSchema.Drivers;

namespace Sqlzor.DbSchema.Services
{
    public class SchemaFetchService : ISchemaFetchService
    {
        protected IDatabaseDriver DatabaseDriver { get; }

        public SchemaFetchService(IDatabaseDriver databaseDriver)
        {
            DatabaseDriver = databaseDriver;
        }

        public virtual async Task<DataTable[]> GetAllSchemaCollections(
            string connectionString,
            int maxConnections)
        {
            var metaDataCollections = await GetSchemaCollection(connectionString, "MetaDataCollections");
            var numberOfConnections = Math.Min(maxConnections, metaDataCollections.Rows.Count);

            var pairs = new List<KeyValuePair<string, Task<DataTable>>>();

            metaDataCollections.Rows.Cast<DataRow>()
                .Select(row => row["CollectionName"] as string)
                .AsParallel()
                .WithDegreeOfParallelism(numberOfConnections)
                .ForAll(collectionName =>
                {
                    try
                    {
                        var collection = GetSchemaCollection(connectionString, collectionName);
                        var pair = new KeyValuePair<string, Task<DataTable>>(collectionName, collection);
                        pairs.Add(pair);
                    }
                    catch (Exception thrown)
                    {
                        Debug.WriteLine($"Unable to load collection {collectionName} [{thrown.Message}]");
                    }
                });

            var tasks = pairs.Select(item => item.Value).ToArray();
            await Task.WhenAll(tasks);

            var dataTables = pairs
                .Where(p => p.Value.Result != null)
                .Select(p => 
                {
                    p.Value.Result.TableName = p.Key; 
                    return p.Value.Result;
                })
                .ToArray();

            return dataTables;
        }

        public virtual async Task<DataTable> GetSchemaCollection(
            string connectionString,
            string collectionName,
            string[] restrictions = null)
        {
            using (var connection = await DatabaseDriver.OpenConnection(connectionString))
            {
                var dataTable = restrictions != null && restrictions.Any()
                    ? connection.GetSchema(collectionName, restrictions)
                    : connection.GetSchema(collectionName);

                return dataTable;
            }
        }
    }
}