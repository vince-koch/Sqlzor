using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.DbSchema;
using Sqlzor.DbSchema.Models;

namespace Sqlzor.Api.Obsolete
{
    public class SchemaApi
    {
        private readonly IConnectionStringService _connectionStringService;
        private readonly ISchemaManager _schemaManagerService;
        private readonly ISchemaTreeBuilder _schemaTreeBuilder;

        public SchemaApi(
            IConnectionStringService connectionStringService,
            ISchemaManager schemaManagerService,
            ISchemaTreeBuilder schemaTreeBuilder)
        {
            _connectionStringService = connectionStringService;
            _schemaManagerService = schemaManagerService;
            _schemaTreeBuilder = schemaTreeBuilder;
        }

        public async Task<Node> GetHierarchyAsync(string connectionName)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var schema = await _schemaManagerService.GetSchema(connectionEntry.ProviderName, connectionEntry.ConnectionString);
            
            var connectionNode = _schemaTreeBuilder.BuildTree(schema);
            connectionNode.Name = connectionName;

            return connectionNode;
        }

        public async Task<SchemaModel> GetSchemaAsync(string connectionName)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var schema = await _schemaManagerService.GetSchema(connectionEntry.ProviderName, connectionEntry.ConnectionString);
            return schema;
        }

        public async Task<DataTable[]> GetSchemaTablesAsync(string connectionName, string collectionName, string[] restrictions)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var databaseDriver = _schemaManagerService.GetDriver(connectionEntry.ProviderName);

            if (string.IsNullOrWhiteSpace(collectionName))
            {
                var dataTables = await databaseDriver.SchemaFetchService
                    .GetAllSchemaCollections(connectionEntry.ConnectionString, 2);
                
                return dataTables;
            }
            else
            {
                var dataTable = await databaseDriver.SchemaFetchService
                    .GetSchemaCollection(connectionEntry.ConnectionString, collectionName, restrictions);
                
                var dataTables = new DataTable[] { dataTable };
                return dataTables;
            }
        }

        public async Task<SchemaModel> MapTables(string connectionName, DataTable[] tables)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var databaseDriver = _schemaManagerService.GetDriver(connectionEntry.ProviderName);
            var schema = databaseDriver.SchemaMapper.MapSchema(tables);
            return schema;
        }

        public Task<Node> BuildHeirarchy(SchemaModel schema)
        {
            var treeBuilder = new SchemaTreeBuilder();
            var node = treeBuilder.BuildTree(schema);
            return Task.FromResult(node);
        }
    }
}