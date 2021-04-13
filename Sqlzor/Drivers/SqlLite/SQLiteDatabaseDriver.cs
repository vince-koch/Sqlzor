using Sqlzor.Drivers.Services;

using System;
using System.Data.Common;
using System.Data.SQLite;

namespace Sqlzor.Drivers.SqlLite
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

        public ISchemaFetchService CreateSchemaFetchService()
        {
            return new SchemaFetchService();
        }

        public ISchemaMapper CreateSchemaMapper()
        {
            return new SQLiteSchemaMapper();
        }
    }
}
