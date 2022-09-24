using System.Data.SqlClient;

using Sqlzor.DbSchema.Drivers;

namespace Sqlzor.DbSchema.SqlServer
{
    public class SqlDatabaseDriver : AbstractDatabaseDriver
    {
        public SqlDatabaseDriver() : base(
            typeof(SqlConnection),
            SqlClientFactory.Instance,
            new SqlSchemaMapper())
        {
        }
    }
}
