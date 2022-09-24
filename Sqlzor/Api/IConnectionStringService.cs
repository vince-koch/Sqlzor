using System.Threading.Tasks;

using Sqlzor.Api.Models;

namespace Sqlzor.Api
{
    public interface IConnectionStringService
    {
        Task<ConnectionStringEntry[]> GetConnectionStringEntries();

        Task<ConnectionStringEntry> GetConnectionStringEntry(string connectionName);

        Task<string[]> GetConnectionNames();

        Task<string[]> GetDriverNames();
    }
}
