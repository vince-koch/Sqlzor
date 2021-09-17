using System.Threading.Tasks;

using Sqlzor.DbSchema;
using Sqlzor.DbSchema.Drivers;
using Sqlzor.DbSchema.Models;

namespace Sqlzor.Services
{
    public class SchemaManagerService : SchemaManager
    {
        private readonly ISchemaPersistanceService _schemaPersistanceService = new SchemaPersistanceService();

        public override async Task<SchemaModel> GetSchema(
            IDatabaseDriver databaseDriver,
            string connectionString,
            int maxConnections = 2)
        {
            var schema = _schemaPersistanceService.LoadSchema(connectionString);
            if (schema == null)
            {
                schema = await base.GetSchema(databaseDriver, connectionString, maxConnections);
                _schemaPersistanceService.SaveSchema(connectionString, schema);
            }

            return schema;
        }
    }
}
