using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers;
using Sqlzor.Drivers.Models;
using Sqlzor.Tree;

namespace Sqlzor.Data
{
    public class SchemaApi
    {
        private readonly ConnectionStringService _connectionStringService;
        private readonly IDatabaseDriverManagerService _databaseDriverManagerService;
        private readonly SchemaTreeBuilder _schemaTreeBuilder;

        public SchemaApi(
            ConnectionStringService connectionStringService,
            IDatabaseDriverManagerService databaseDriverManagerService,
            SchemaTreeBuilder schemaTreeBuilder)
        {
            _connectionStringService = connectionStringService;
            _databaseDriverManagerService = databaseDriverManagerService;
            _schemaTreeBuilder = schemaTreeBuilder;
        }

        public async Task<SchemaModel> GetSchemaAsync(string connectionName)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var schema = await _databaseDriverManagerService.GetSchema(connectionEntry.ProviderName, connectionEntry.ConnectionString);
            var connectionNode = _schemaTreeBuilder.BuildTree(schema);

            return schema;
        }

        public async Task<DataTable[]> GetSchemaTablesAsync(string connectionName, string collectionName, string[] restrictions)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var databaseDriver = _databaseDriverManagerService.GetDriver(connectionEntry.ProviderName);
            var schemaFetchService = databaseDriver.CreateSchemaFetchService();

            if (string.IsNullOrWhiteSpace(collectionName))
            {
                var dataTables = await schemaFetchService.GetAllSchemaCollections(connectionEntry.ConnectionString, 2);
                return dataTables;
            }
            else
            {
                var dataTable = await schemaFetchService.GetSchemaCollection(connectionEntry.ConnectionString, collectionName, restrictions);
                var dataTables = new DataTable[] { dataTable };
                return dataTables;
            }
        }

        public async Task<SchemaModel> MapTables(string connectionName, DataTable[] tables)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var databaseDriver = _databaseDriverManagerService.GetDriver(connectionEntry.ProviderName);
            var schemaMapper = databaseDriver.CreateSchemaMapper();
            var schema = schemaMapper.MapSchema(tables);
            return schema;
        }

        public Task<ConnectionNode> BuildHeirarchy(SchemaModel schema)
        {
            throw new NotImplementedException();
        }
    }
}
