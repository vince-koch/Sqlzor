using Npgsql;

using Sqlzor.DbSchema.Drivers;

namespace Sqlzor.DbSchema.Postgres
{
    public class NpgsqlDatabaseDriver : AbstractDatabaseDriver
    {
        public NpgsqlDatabaseDriver() : base(
            typeof(NpgsqlConnection),
            NpgsqlFactory.Instance, 
            new NpgsqlSchemaMapper())
        {
        }
    }
}
