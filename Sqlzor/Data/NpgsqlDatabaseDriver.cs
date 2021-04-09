using System.Data.Common;

using Npgsql;

namespace Sqlzor.Data
{
    public class NpgsqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "Npgsql";

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
