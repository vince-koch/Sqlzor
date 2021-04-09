using System.Data.Common;
using System.Data.SqlClient;

namespace Sqlzor.Data.Drivers
{
    public class SqlServerDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "System.Data.SqlClient";

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
