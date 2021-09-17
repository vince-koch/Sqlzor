using System;
using System.Data.Common;

using Npgsql;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.Postgres
{
    public class NpgsqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "Npgsql";

        public Type ConnectionType => typeof(NpgsqlConnection);

        public ISchemaFetchService SchemaFetchService { get; }
    
        public ISchemaMapper SchemaMapper { get; }

        public NpgsqlDatabaseDriver()
        {
            SchemaFetchService = new NpgsqlSchemaFetchService(this);
            SchemaMapper = new NpgsqlSchemaMapper();
        }

        public DbConnection CreateConnection()
        {
            return new NpgsqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new NpgsqlConnectionStringBuilder();
        }
    }
}
