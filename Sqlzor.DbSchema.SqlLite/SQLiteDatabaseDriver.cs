using System;
using System.Data.Common;
using System.Data.SQLite;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.SqlLite
{
    public class SQLiteDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "System.Data.SQLite";

        public Type ConnectionType => typeof(SQLiteConnection);

        public ISchemaFetchService SchemaFetchService { get; }

        public ISchemaMapper SchemaMapper { get; }

        public SQLiteDatabaseDriver()
        {
            SchemaFetchService = new SchemaFetchService(this);
            SchemaMapper = new SQLiteSchemaMapper();
        }

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
