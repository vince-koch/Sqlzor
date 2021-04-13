using System.Collections.Generic;
using System.Data;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Drivers
{
    public interface ISchemaMapper
    {
        SchemaModel ConvertSchema(Dictionary<string, DataTable> dataTables);
    }
}
