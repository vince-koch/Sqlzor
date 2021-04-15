using System;
using System.Data.Common;

using MySql.Data.MySqlClient;

using Sqlzor.Drivers.Services;

namespace Sqlzor.Drivers.MySql
{
    public class MySqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.MySql;

        public Type ConnectionType => typeof(MySqlConnection);

        public DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new MySqlConnectionStringBuilder();
        }

        public ISchemaFetchService CreateSchemaFetchService()
        {
            return new SchemaFetchService(this);
        }

        public ISchemaMapper CreateSchemaMapper()
        {
            return new MySqlSchemaMapper();
        }
    }
}
