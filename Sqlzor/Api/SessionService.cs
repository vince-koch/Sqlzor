using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Api.Models;
using Sqlzor.DbSchema;

namespace Sqlzor.Api
{
    public class SessionService : ISessionService
    {
        private static List<SessionModel> _sessions = new List<SessionModel>();

        private readonly IConnectionStringService _connectionStringService;
        private readonly ISchemaManager _schemaManagerService;
        private readonly ISchemaTreeBuilder _schemaTreeBuilder;

        public SessionService(
            IConnectionStringService connectionStringService,
            ISchemaManager schemaManagerService,
            ISchemaTreeBuilder schemaTreeBuilder)
        {
            _connectionStringService = connectionStringService;
            _schemaManagerService = schemaManagerService;
            _schemaTreeBuilder = schemaTreeBuilder;
        }

        public SessionModel[] GetSessions()
        {
            return _sessions.ToArray();
        }

        public SessionModel GetSession(Guid sessionId)
        {
            lock (_sessions)
            {
                var session = _sessions.SingleOrDefault(item => item.SessionId == sessionId);
                return session;
            }
        }

        public async Task<SessionModel> OpenSession(string connectionName)
        {
            try
            {
                var entry = await _connectionStringService.GetConnectionStringEntry(connectionName);
                var driver = _schemaManagerService.GetDriver(entry.ProviderName);
                var connection = await driver.OpenConnection(entry.ConnectionString);

                var session = new SessionModel
                {
                    SessionId = Guid.NewGuid(),
                    SessionName = entry.Name,
                    Driver = driver,
                    Connetion = connection,
                    Schema = null
                };

                lock (_sessions)
                {
                    _sessions.Add(session);
                }

                return session;
            }
            catch (Exception thrown)
            {
                Debug.WriteLine(thrown);
                throw;
            }
        }

        public SessionModel OpenSession(string providerNae, StringDictionary properties)
        {
            throw new NotImplementedException();
        }

        public async Task CloseSession(Guid sessionid)
        {
            var session = GetSession(sessionid);

            lock (_sessions)
            {    
                _sessions.Remove(session);
            }

            await session.Connetion.CloseAsync();
            await session.Connetion.DisposeAsync();
        }

        public async Task<DataTable[]> ExecuteQuery(Guid sessionId, string queryText)
        {
            queryText = await TryReadFile(queryText);

            var session = GetSession(sessionId);

            var factory = DbProviderFactories.GetFactory(session.Connetion);
            using (var command = session.Connetion.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = queryText;
                command.CommandTimeout = 0;

                var result = new List<DataTable>();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    do
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        result.Add(table);
                    }
                    while (!reader.IsClosed && reader.HasRows);
                }

                return result.ToArray();
            }
        }

        public async Task<SessionModel> RefreshHierarchy(Guid sessionId)
        {
            var session = GetSession(sessionId);
            await GetHierarchy(session);
            return session;
        }

        private async Task GetHierarchy(SessionModel session)
        {
            var schema = await _schemaManagerService.GetSchema(
                session.Driver.ProviderName,
                session.Connetion.ConnectionString);

            var connectionNode = _schemaTreeBuilder.BuildTree(schema);
            connectionNode.Name = session.SessionName;

            session.Schema = connectionNode;
        }

        private async Task<string> TryReadFile(string path)
        {
            try
            {
                if (File.Exists(path.Trim()))
                {
                    var queryText = await File.ReadAllTextAsync(path.Trim());
                    return queryText;
                }
            }
            catch
            {
                // we're doing something kind of dumb here, so just ignore it if things go sideways
            }

            return path;
        }
    }
}