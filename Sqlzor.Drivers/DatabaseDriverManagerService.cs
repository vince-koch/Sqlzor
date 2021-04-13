using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Sqlzor.Drivers
{
    public class DatabaseDriverManagerService : IDatabaseDriverManagerService
    {
        private readonly IDatabaseDriver[] _databaseDrivers;

        public DatabaseDriverManagerService(IEnumerable<IDatabaseDriver> databaseDrivers)
        {
            _databaseDrivers = _databaseDrivers.ToArray();
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
    }
}
