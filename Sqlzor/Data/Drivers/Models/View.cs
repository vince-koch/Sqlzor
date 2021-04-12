using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Views")]
    [DebuggerDisplay("View [{TableCatalog}.{TableSchema}.{TableName}]")]
    public class View
    {
        [SchemaColumn("TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [SchemaColumn("TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [SchemaColumn("TABLE_NAME")]
        public string TableName { get; set; }
    }
}
