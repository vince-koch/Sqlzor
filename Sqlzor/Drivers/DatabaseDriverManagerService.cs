using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;
using Sqlzor.Drivers.Services;

namespace Sqlzor.Drivers
{
    public class DatabaseDriverManagerService : IDatabaseDriverManagerService
    {
        private readonly IDatabaseDriver[] _databaseDrivers;
        private readonly ISchemaPersistanceService _schemaPersistanceService;

        public DatabaseDriverManagerService(
            IEnumerable<IDatabaseDriver> databaseDrivers,
            ISchemaPersistanceService schemaPersistanceService)
        {
            _databaseDrivers = databaseDrivers.ToArray();
            _schemaPersistanceService = schemaPersistanceService;
        }

        public IDatabaseDriver GetDriver(string providerName)
        {
            var driver = _databaseDrivers.Single(item => item.ProviderName == providerName);
            return driver;
        }

        public IDatabaseDriver GetDriver(DbConnection connection)
        {
            var connectionType = connection.GetType();
            var driver = _databaseDrivers.Single(item => item.ConnectionType == connectionType);
            return driver;
        }

        public async Task<SchemaModel> GetSchema(
            string providerName,
            string connectionString,
            int maxConnections = 2)
        {
            var driver = GetDriver(providerName);
            var result = await GetSchema(driver, connectionString, maxConnections);
            return result;
        }

        public async Task<SchemaModel> GetSchema(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections = 2)
        {
            var schema = _schemaPersistanceService.LoadSchema(connectionString);
            if (schema == null)
            {
                var schemaFetchService = databaseDriver.CreateSchemaFetchService();

                var dataTables = await schemaFetchService.FetchSchemaTables(
                    databaseDriver,
                    connectionString,
                    maxConnections);

                var schemaMapper = databaseDriver.CreateSchemaMapper();
                schema = schemaMapper.MapSchema(dataTables);

                _schemaPersistanceService.SaveSchema(connectionString, schema);
            }

            return schema;
        }
    }
}
