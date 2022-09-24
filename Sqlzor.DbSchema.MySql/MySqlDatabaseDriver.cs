using MySql.Data.MySqlClient;

using Sqlzor.DbSchema.Drivers;

namespace Sqlzor.DbSchema.MySql
{
    public class MySqlDatabaseDriver : AbstractDatabaseDriver
    {
        public MySqlDatabaseDriver() : base(
            typeof(MySqlConnection),
            MySqlClientFactory.Instance,
            new MySqlSchemaMapper())
        {
        }
    }
}
