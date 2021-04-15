using Sqlzor.Drivers;

using System.Data.Common;
using System.Threading.Tasks;

namespace Sqlzor
{
    public static partial class ExtensionMethods
    {
        public static async Task<DbConnection> OpenConnection(this IDatabaseDriver databaseDriver, string connectionString)
        {
            var connection = databaseDriver.CreateConnection();
            connection.ConnectionString = connectionString;
            await connection.OpenAsync();
            return connection;
        }
    }
}
