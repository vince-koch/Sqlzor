using System;
using System.Data.Common;

using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.Drivers
{
    public interface IDatabaseDriver
    {
        string ProviderInvariantName { get; }

        Type ConnectionType { get; }

        ISchemaFetchService SchemaFetchService { get; }

        ISchemaMapper SchemaMapper { get; }

        DbProviderFactory GetProviderFactory();

        DbConnectionStringBuilder CreateConnectionStringBuilder();

        DbConnection CreateConnection();
    }
}
