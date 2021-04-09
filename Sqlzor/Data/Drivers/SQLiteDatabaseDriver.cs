using System.Data.Common;
using System.Data.SQLite;

namespace Sqlzor.Data.Drivers
{
    public class SQLiteDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "System.Data.SQLite";

        public DbConnection CreateConnection()
        {
            return new SQLiteConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new SQLiteConnectionStringBuilder();
        }
    }
}
