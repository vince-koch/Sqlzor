using System.Data.Common;
using System.Threading.Tasks;

using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Models;

namespace Sqlzor.DbSchema
{
    public interface ISchemaManager
    {
        ISchemaManager RegisterDriver<TDatabaseDriver>()
            where TDatabaseDriver : IDatabaseDriver, new();
        
        ISchemaManager RegisterDriver(IDatabaseDriver databaseDriver);

        IDatabaseDriver GetDriver(string providerName);

        IDatabaseDriver GetDriver(DbConnection connection);

        string[] GetProviderNames();

        Task<SchemaModel> GetSchema(
            string providerName,
            string connectionString,
            int maxConnections = 2);

        Task<SchemaModel> GetSchema(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections = 2);
    }
}
