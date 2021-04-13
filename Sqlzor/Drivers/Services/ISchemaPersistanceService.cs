using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers.Services
{
    public interface ISchemaPersistanceService
    {
        SchemaModel LoadSchema(string connectionString);

        void SaveSchema(string connectionString, SchemaModel schema);
    }
}
