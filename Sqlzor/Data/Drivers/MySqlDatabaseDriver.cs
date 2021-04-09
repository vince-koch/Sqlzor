using System;
using System.Data.Common;

using MySql.Data.MySqlClient;

namespace Sqlzor.Data.Drivers
{
    public class MySqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "MySql.Data.MySqlClient";

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
