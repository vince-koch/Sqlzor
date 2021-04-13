using System;
using System.Data.Common;

using Npgsql;

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
    }
}
