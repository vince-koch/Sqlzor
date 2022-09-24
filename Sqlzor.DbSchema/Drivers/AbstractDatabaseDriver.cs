using System;
using System.Data.Common;

using Sqlzor.DbSchema.Services;

namespace Sqlzor.DbSchema.Drivers
{
    public abstract class AbstractDatabaseDriver : IDatabaseDriver
    {
        public string ProviderInvariantName => DbProviderFactory.GetType().Namespace;

        public DbProviderFactory DbProviderFactory { get; }

        public Type ConnectionType { get; }

        public ISchemaMapper SchemaMapper { get; }

        public ISchemaFetchService SchemaFetchService { get; }

        protected AbstractDatabaseDriver(
            Type connectionType,
            DbProviderFactory dbProviderFactory,
            ISchemaMapper schemaMapper)
        {
            ConnectionType = connectionType;
            DbProviderFactory = dbProviderFactory;
            SchemaMapper = schemaMapper;
            SchemaFetchService = new SchemaFetchService(this);

            DbProviderFactories.RegisterFactory(ProviderInvariantName, DbProviderFactory);
        }

        public DbProviderFactory GetProviderFactory()
        {
            var factory = DbProviderFactories.GetFactory(ProviderInvariantName);
            return factory;
        }

        public DbConnection CreateConnection()
        {
            var factory = GetProviderFactory();
            var connection = factory.CreateConnection();
            return connection;
        }

        public DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            var factory = GetProviderFactory();
            var connectionStringBuilder = factory.CreateConnectionStringBuilder();
            return connectionStringBuilder;
        }
    }
}
