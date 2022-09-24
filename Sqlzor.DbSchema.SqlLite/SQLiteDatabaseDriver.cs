using System.Data.SQLite;

using Sqlzor.DbSchema.Drivers;

namespace Sqlzor.DbSchema.SqlLite
{
    public class SQLiteDatabaseDriver : AbstractDatabaseDriver
    {
        public SQLiteDatabaseDriver() : base(
            typeof(SQLiteConnection),
            SQLiteFactory.Instance,
            new SQLiteSchemaMapper())
        {
        }
    }
}
