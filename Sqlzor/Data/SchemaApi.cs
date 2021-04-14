using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers;

namespace Sqlzor.Data
{
    public class SchemaApi
    {
        private readonly ConnectionStringService _connectionStringService;
        private readonly IDatabaseDriverManagerService _databaseDriverManagerService;

        public SchemaApi(
            ConnectionStringService connectionStringService,
            IDatabaseDriverManagerService databaseDriverManagerService)
        {
            _connectionStringService = connectionStringService;
            _databaseDriverManagerService = databaseDriverManagerService;
        }

        public async Task<DataTable[]> GetSchemaTablesAsync(string connectionName, string collectionName, string[] restrictions)
        {
            var connectionEntry = await _connectionStringService.GetConnectionStringEntry(connectionName);
            var databaseDriver = _databaseDriverManagerService.GetDriver(connectionEntry.ProviderName);
            var schemaFetchService = databaseDriver.CreateSchemaFetchService();

            if (string.IsNullOrWhiteSpace(collectionName))
            {
                var dictionary = await schemaFetchService.GetAllSchemaCollections(connectionEntry.ConnectionString, 2);
                var result = dictionary.Values.Where(table => table != null).ToArray();
                return result;
            }
            else
            {
                var dataTable = await schemaFetchService.GetSchemaCollection(connectionEntry.ConnectionString, collectionName, restrictions);
                var result = new DataTable[] { dataTable };
                return result;
            }
        }
    }
}
