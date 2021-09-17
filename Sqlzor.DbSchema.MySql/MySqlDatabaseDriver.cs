using System;
using System.Data.Common;

using MySql.Data.MySqlClient;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.MySql
{
    public class MySqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "MySql.Data.MySqlClient";

        public Type ConnectionType => typeof(MySqlConnection);

        public ISchemaFetchService SchemaFetchService { get; }

        public ISchemaMapper SchemaMapper { get; }

        public MySqlDatabaseDriver()
        {
            SchemaFetchService = new SchemaFetchService(this);
            SchemaMapper = new MySqlSchemaMapper();
        }

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
