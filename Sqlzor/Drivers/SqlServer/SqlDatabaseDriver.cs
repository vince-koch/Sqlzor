using System;
using System.Data.Common;
using System.Data.SqlClient;

using Sqlzor.Drivers.Services;

namespace Sqlzor.Drivers.SqlServer
{
    public class SqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => ProviderNames.SqlServer;

        public Type ConnectionType => typeof(SqlConnection);

        public DbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new SqlConnectionStringBuilder();
        }

        public ISchemaFetchService CreateSchemaFetchService()
        {
            return new SchemaFetchService(this);
        }

        public ISchemaMapper CreateSchemaMapper()
        {
            return new SqlSchemaMapper();
        }
    }
}
