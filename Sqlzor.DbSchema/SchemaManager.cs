using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Models;

namespace Sqlzor.DbSchema
{
    public class SchemaManager : ISchemaManager
    {
        private readonly List<IDatabaseDriver> _databaseDrivers = new List<IDatabaseDriver>();

        public SchemaManager()
        {
        }
        
        public SchemaManager(
            IEnumerable<IDatabaseDriver> databaseDrivers)
        {
            _databaseDrivers.AddRange(databaseDrivers);
        }

        public ISchemaManager RegisterDriver<TDatabaseDriver>()
            where TDatabaseDriver : IDatabaseDriver, new()
        {
            var databaseDriver = new TDatabaseDriver();
            RegisterDriver(databaseDriver);
            return this;
        }

        public ISchemaManager RegisterDriver(IDatabaseDriver databaseDriver)
        {
            _databaseDrivers.Add(databaseDriver);
            return this;
        }

        public IDatabaseDriver GetDriver(string providerName)
        {
            var driver = _databaseDrivers.Single(item => item.ProviderInvariantName == providerName);
            return driver;
        }

        public IDatabaseDriver GetDriver(DbConnection connection)
        {
            var connectionType = connection.GetType();
            var driver = _databaseDrivers.Single(item => item.ConnectionType == connectionType);
            return driver;
        }

        public string[] GetProviderNames()
        {
            var providerNames = _databaseDrivers
                .Select(driver => driver.ProviderInvariantName)
                .Distinct()
                .ToArray();

            return providerNames;
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

        public virtual async Task<SchemaModel> GetSchema(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections = 2)
        {
            var dataTables = await databaseDriver
                .SchemaFetchService
                .GetAllSchemaCollections(connectionString, maxConnections);

            var schema = databaseDriver
                .SchemaMapper
                .MapSchema(dataTables);

            schema.ProviderName = databaseDriver.ProviderInvariantName;
            
            return schema;
        }
    }
}
