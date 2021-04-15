using System.Data.Common;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers
{
    public interface IDatabaseDriverManagerService
    {
        IDatabaseDriver GetDriver(string providerName);

        IDatabaseDriver GetDriver(DbConnection connection);

        Task<SchemaModel> GetSchema(
            string providerName,
            string connectionString,
            int maxConnections = 2);

        Task<SchemaModel> GetSchema(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections = 2);
    }
}
