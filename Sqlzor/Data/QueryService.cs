using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using Sqlzor.Data.Drivers;

namespace Sqlzor.Data
{
    public class QueryService
    {
        private readonly AppSettingsService _appSettings;
        private readonly IDatabaseDriver[] _databaseDrivers;

        public QueryService(
            AppSettingsService appSettings,
            IEnumerable<IDatabaseDriver> databaseDrivers)
        {
            _appSettings = appSettings;
            _databaseDrivers = databaseDrivers.ToArray();
        }

        public async Task<ConnectionStringEntry[]> GetConnectionStringEntries()
        {
            using (var stream = File.OpenRead(_appSettings.ConnectionStringsFile))
            {
                var document = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);

                var connectionStringEntries = document.Descendants()
                    .Where(item => item.Name.LocalName == "add")
                    .Select(item => new ConnectionStringEntry
                    {
                        Name = item.Attribute("name").Value,
                        ProviderName = item.Attribute("providerName")?.Value,
                        ConnectionString = item.Attribute("connectionString").Value
                    })
                    .ToArray();

                return connectionStringEntries;
            }
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
