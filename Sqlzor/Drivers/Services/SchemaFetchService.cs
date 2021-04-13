using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlzor.Drivers.Services
{
    public class SchemaFetchService : ISchemaFetchService
    {
        public virtual async Task<Dictionary<string, DataTable>> FetchSchemaTables(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections)
        {
            var metaDataCollections = await GetCollection(databaseDriver, connectionString, "MetaDataCollections");
            var numberOfConnections = Math.Min(maxConnections, metaDataCollections.Rows.Count);

            var pairs = new List<KeyValuePair<string, Task<DataTable>>>();

            metaDataCollections.Rows.Cast<DataRow>()
                .Select(row => row["CollectionName"] as string)
                .AsParallel()
                .WithDegreeOfParallelism(numberOfConnections)
                .ForAll(collectionName =>
                {
                    var collection = GetCollection(databaseDriver, connectionString, collectionName);
                    var pair = new KeyValuePair<string, Task<DataTable>>(collectionName, collection);
                    pairs.Add(pair);
                });

            var tasks = pairs.Select(item => item.Value).ToArray();
            await Task.WhenAll(tasks);

            var dataTables = pairs.ToDictionary(p => p.Key, p => p.Value.Result);
            return dataTables;
        }

        protected virtual async Task<DataTable> GetCollection(
            IDatabaseDriver databaseDriver,
            string connectionString,
            string collectionName)
        {
            try
            {
                using (var connection = await databaseDriver.OpenConnection(connectionString))
                {
                    var dataTable = connection.GetSchema(collectionName);
                    return dataTable;
                }
            }
            catch (Exception thrown)
            {
                Debug.WriteLine($"Unable to load collection {collectionName} [{thrown.Message}]");
                return null;
            }
        }
    }
}