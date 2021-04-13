using System;
using System.Data.Common;

using Npgsql;

using Sqlzor.Drivers.Services;

namespace Sqlzor.Drivers.Postgres
{
    public class NpgsqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.Postgres;

        public Type ConnectionType => typeof(NpgsqlConnection);

        public DbConnection CreateConnection()
        {
            return new NpgsqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new NpgsqlConnectionStringBuilder();
        }

        public ISchemaFetchService CreateSchemaFetchService()
        {
            return new NpgsqlSchemaFetchService();
        }

        public ISchemaMapper CreateSchemaMapper()
        {
            return new NpgsqlSchemaMapper();
        }
    }
}
