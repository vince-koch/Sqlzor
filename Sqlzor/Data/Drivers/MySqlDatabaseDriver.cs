using System;
using System.Data.Common;

using MySql.Data.MySqlClient;

namespace Sqlzor.Data.Drivers
{
    public class MySqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.MySql;

        public DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new MySqlConnectionStringBuilder();
        }
    }
}
