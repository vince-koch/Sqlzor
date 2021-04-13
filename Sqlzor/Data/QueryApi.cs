using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers;

namespace Sqlzor.Data
{
    public class QueryApi
    {
        private readonly ConnectionStringService _connectionStringService;
        private readonly IDatabaseDriver[] _databaseDrivers;

        public QueryApi(
            ConnectionStringService connectionStringService,
            IEnumerable<IDatabaseDriver> databaseDrivers)
        {
            _connectionStringService = connectionStringService;
            _databaseDrivers = databaseDrivers.ToArray();
        }

        // todo: remove this method
        public async Task<ConnectionStringEntry[]> GetConnectionStringEntries()
        {
            return await _connectionStringService.GetConnectionStringEntries();
        }

        public Task<string[]> GetProviderNames()
        {
            var providerNames = _databaseDrivers
                .Select(item => item.ProviderName)
                .ToArray();

            return Task.FromResult(providerNames);
        }

        public async Task<string[]> GetConnectionNames()
        {
            var connectionStringEntries = await GetConnectionStringEntries();

            var connectionNames = connectionStringEntries
                .Select(item => item.Name)
                .ToArray();

            return connectionNames;
        }

        public async Task<DataTable> ExecuteAsync(string connectionStringName, string queryText)
        {
            using (var connection = await OpenNamedConnectionAsync(connectionStringName))
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = queryText;

                using (var reader = await command.ExecuteReaderAsync())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
            }
        }

        public async Task<DataTable> GetSchemaAsync(string connectionStringName, string collectionName, string[] restrictionValues)
        {
            using (var connection = await OpenNamedConnectionAsync(connectionStringName))
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var dataTable = connection.GetSchema();
                var tables = new Dictionary<string, object>();
                tables.Add(string.Empty, dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    var tableCollectionName = row[0].ToString();
                    try
                    {
                        var table = connection.GetSchema(tableCollectionName);
                        tables.Add(tableCollectionName, table);
                    }
                    catch (Exception thrown)
                    {
                        tables.Add(tableCollectionName, thrown.Message);
                    }
                }

                stopwatch.Stop();

                foreach (var pair in tables)
                {
                    Debug.WriteLine(string.Empty);
                    Debug.WriteLine(pair.Key);
                    Debug.WriteLine((pair.Value as DataTable)?.AsString() ?? pair.Value);
                }

                Debug.WriteLine(string.Empty);
                Debug.WriteLine($"{tables.Count} tables returned in {stopwatch.Elapsed}");

                return dataTable;
            }
        }
        
        /*
        public async Task<DataTable> GetSchemaAsync(string connectionStringName, string collectionName, string[] restrictionValues)
        {
            using (var connection = await OpenNamedConnectionAsync(connectionStringName))
            {
                DataTable dataTable = null;
                
                if (!string.IsNullOrWhiteSpace(collectionName))
                {
                    if (restrictionValues != null && restrictionValues.Length > 0)
                    {
                        dataTable = connection.GetSchema(collectionName, restrictionValues);
                    }
                    else
                    {
                        dataTable = connection.GetSchema(collectionName);
                    }
                }
                else
                {
                    dataTable = connection.GetSchema();
                }

                return dataTable;
            }
        }
        */

        private async Task<IDatabaseDriver> GetDatabaseDriver(string connectionStringName)
        {
            var connectionStringEntries = await GetConnectionStringEntries();
            var connectionEntry = connectionStringEntries.Single(item => item.Name == connectionStringName);
            var databaseDriver = _databaseDrivers.Single(item => item.ProviderName == connectionEntry.ProviderName);
            return databaseDriver;
        }

        private async Task<DbConnection> OpenNamedConnectionAsync(string connectionStringName)
        {
            var connectionStringEntries = await GetConnectionStringEntries();
            var connectionEntry = connectionStringEntries.Single(item => item.Name == connectionStringName);
            var databaseDriver = _databaseDrivers.Single(item => item.ProviderName == connectionEntry.ProviderName);

            var connection = databaseDriver.CreateConnection();
            connection.ConnectionString = connectionEntry.ConnectionString;
            await connection.OpenAsync();

            return connection;
        }
    }
}
