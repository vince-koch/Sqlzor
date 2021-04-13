using System;
using System.Data.Common;
using System.Data.SQLite;

namespace Sqlzor.Data.Drivers.SqlLite
{
    public class SQLiteDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.SQLite;

        public Type ConnectionType => typeof(SQLiteConnection);

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
