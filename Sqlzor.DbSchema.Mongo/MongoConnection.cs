using MongoDB.Driver;

using System.Data;
using System.Data.Common;

namespace Sqlzor.DbSchema.Mongo
{
    internal class MongoConnection : DbConnection
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;

        public override string ConnectionString { get; set; }

        public override string Database => _mongoDatabase?.DatabaseNamespace.DatabaseName;

        public override string DataSource => throw new NotImplementedException();

        public override string ServerVersion => throw new NotImplementedException();

        public override ConnectionState State 
        {
            get
            {
                if (_mongoClient == null || _mongoDatabase == null)
                {
                    return ConnectionState.Closed;
                }

                return ConnectionState.Open;
            }
        }

        public override void ChangeDatabase(string databaseName)
        {
            ArgumentNullException.ThrowIfNull(_mongoClient, nameof(_mongoClient));
            _mongoDatabase = _mongoClient.GetDatabase(databaseName);
        }

        public override void Close()
        {
            _mongoDatabase = null;
            _mongoClient = null;
        }

        public override void Open()
        {
            Close();

            _mongoClient = new MongoClient(ConnectionString);
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }
    }
}
