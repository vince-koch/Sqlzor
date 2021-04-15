using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers;

namespace Sqlzor.Data
{
    public class QueryApi
    {
        private readonly ConnectionStringService _connectionStringService;
        private readonly IDatabaseDriverManagerService _databaseDriverManagerService;

        public QueryApi(
            ConnectionStringService connectionStringService,
            IDatabaseDriverManagerService databaseDriverManagerService)
        {
            _connectionStringService = connectionStringService;
            _databaseDriverManagerService = databaseDriverManagerService;
        }

        public async Task<string[]> GetConnectionNames()
        {
            var connectionStringEntries = await _connectionStringService.GetConnectionStringEntries();

            var connectionNames = connectionStringEntries
                .Select(item => item.Name)
                .ToArray();

            return connectionNames;
        }

        public async Task<DataTable[]> ExecuteAsync(string connectionStringName, string queryText)
        {
            queryText = await TryReadFile(queryText);

            using (var connection = await OpenNamedConnectionAsync(connectionStringName))
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = queryText;
                command.CommandTimeout = 0;

                var result = new List<DataTable>();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    do
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        result.Add(table);
                    }
                    while (!reader.IsClosed && reader.HasRows);
                }

                return result.ToArray();
            }
        }

        private async Task<string> TryReadFile(string path)
        {
            try
            {
                if (File.Exists(path.Trim()))
                {
                    var queryText = await File.ReadAllTextAsync(path.Trim());
                    return queryText;
                }
            }
            catch
            {
                // we're doing something kind of dumb here, so just ignore it if things go sideways
            }

            return path;
        }

        private async Task<DbConnection> OpenNamedConnectionAsync(string connectionStringName)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionStringName);
            var databaseDriver = _databaseDriverManagerService.GetDriver(connectionEntry.ProviderName);
            var connection = databaseDriver.CreateConnection();
            connection.ConnectionString = connectionEntry.ConnectionString;
            await connection.OpenAsync();

            return connection;
        }
    }
}
