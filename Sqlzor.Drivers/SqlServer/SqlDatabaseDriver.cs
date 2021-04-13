using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Sqlzor.Data.Drivers.SqlServer
{
    public class SqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.SqlServer;

        public Type ConnectionType => typeof(SqlConnection);

        public DbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new SqlConnectionStringBuilder();
        }
    }
}
