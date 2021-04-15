using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sqlzor.Drivers.Services
{
    public interface ISchemaFetchService
    {
        Task<DataTable[]> GetAllSchemaCollections(
            string connectionString,
            int maxConnections);

        Task<DataTable> GetSchemaCollection(
            string connectionString,
            string collectionName,
            string[] restrictions = null);
    }
}
