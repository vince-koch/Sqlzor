using Sqlzor.DbSchema.Models;

namespace Sqlzor.Services
{
    public interface ISchemaPersistanceService
    {
        SchemaModel LoadSchema(string connectionString);

        void SaveSchema(string connectionString, SchemaModel schema);
    }
}
