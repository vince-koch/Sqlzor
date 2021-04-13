using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlzor.Drivers
{
    public static partial class ExtensionMethods
    {
        public static async Task<DbConnection> OpenCloneAsync(this DbConnection connection)
        {
            var connectionType = connection.GetType();

            var constructor = connectionType.GetConstructor(new Type[0]);
            if (constructor == null)
            {
                throw new NotSupportedException($"{connectionType.Name} does not have a default constructor");
            }

            var clone = constructor.Invoke(new object[0]) as DbConnection;
            clone.ConnectionString = connection.ConnectionString;
            await clone.OpenAsync();

            return clone;
        }

        public static async Task<Dictionary<string, DataTable>> GetSchemaCollectionsAsync(this DbConnection connection, int maxConnections = 2)
        {
            var metaDataCollections = await GetSchemaCollection(connection, "MetaDataCollections");
            var numberOfConnections = Math.Min(maxConnections, metaDataCollections.Rows.Count);

            var pairs = new List<KeyValuePair<string, Task<DataTable>>>();

            metaDataCollections.Rows.Cast<DataRow>()
                .Select(row => row["CollectionName"] as string)
                .AsParallel()
                .WithDegreeOfParallelism(numberOfConnections)
                .ForAll(collectionName =>
                {
                    var collection = GetSchemaCollection(connection, collectionName);
                    var pair = new KeyValuePair<string, Task<DataTable>>(collectionName, collection);
                    pairs.Add(pair);
                });

            var tasks = pairs.Select(item => item.Value).ToArray();
            await Task.WhenAll(tasks);

            var dataTables = pairs.ToDictionary(p => p.Key, p => p.Value.Result);
            return dataTables;
        }

        private static async Task<DataTable> GetSchemaCollection(DbConnection source, string collectionName)
        {
            try
            {
                using (var connection = await source.OpenCloneAsync())
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
