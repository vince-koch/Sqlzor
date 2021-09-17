using System.Collections.Generic;
using System.Data;

using Sqlzor.DbSchema.Models;

namespace Sqlzor.DbSchema.Drivers
{
    public interface ISchemaMapper
    {
        SchemaModel MapSchema(DataTable[] dataTables);
    }
}
