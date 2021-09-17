using System;
using System.Data.Common;

using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.Drivers
{
    public interface IDatabaseDriver
    {
        string ProviderName { get; }

        Type ConnectionType { get; }

        ISchemaFetchService SchemaFetchService { get; }

        ISchemaMapper SchemaMapper { get; }

        DbConnectionStringBuilder CreateConnectionStringBuilder();

        DbConnection CreateConnection();
    }
}
