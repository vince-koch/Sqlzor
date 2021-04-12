using System.Data.Common;

using Npgsql;

namespace Sqlzor.Data.Drivers
{
    public class NpgsqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.Postgres;

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
