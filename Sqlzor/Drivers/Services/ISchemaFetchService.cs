using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sqlzor.Drivers.Services
{
    public interface ISchemaFetchService
    {
        Task<Dictionary<string, DataTable>> FetchSchemaTables(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections);
    }
}
