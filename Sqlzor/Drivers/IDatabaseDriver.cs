using Sqlzor.Drivers.Services;

using System;
using System.Data.Common;

namespace Sqlzor.Drivers
{
    public interface IDatabaseDriver
    {
        string ProviderName { get; }

        Type ConnectionType { get; }

        DbConnectionStringBuilder CreateConnectionStringBuilder();

        DbConnection CreateConnection();

        ISchemaFetchService CreateSchemaFetchService();

        ISchemaMapper CreateSchemaMapper();
    }
}
