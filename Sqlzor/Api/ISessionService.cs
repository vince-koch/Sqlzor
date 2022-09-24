using System;
using System.Data;
using System.Threading.Tasks;

using Sqlzor.Api.Models;

namespace Sqlzor.Api
{
    public interface ISessionService
    {
        SessionModel[] GetSessions();

        SessionModel GetSession(Guid sessionId);

        Task<SessionModel> OpenSession(string connectionName);

        Task<SessionModel> OpenSession(string sessionName, string driverName, string connectionString);

        Task CloseSession(Guid sessionid);

        Task<DataTable[]> ExecuteQuery(Guid sessionId, string queryText);

        Task<SessionModel> RefreshHierarchy(Guid sessionId);
    }
}
