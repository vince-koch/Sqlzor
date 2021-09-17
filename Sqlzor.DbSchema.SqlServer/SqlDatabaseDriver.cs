using System;
using System.Data.Common;
using System.Data.SqlClient;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.SqlServer
{
    public class SqlDatabaseDriver : IDatabaseDriver
    {
        public string ProviderName => "System.Data.SqlClient";

        public Type ConnectionType => typeof(SqlConnection);

        public ISchemaFetchService SchemaFetchService { get; }

        public ISchemaMapper SchemaMapper { get; }

        public SqlDatabaseDriver()
        {
            SchemaFetchService = new SchemaFetchService(this);
            SchemaMapper = new SqlSchemaMapper();
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return new SqlConnectionStringBuilder();
        }
    }
}
