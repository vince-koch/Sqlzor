using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Tables")]
    [DebuggerDisplay("Table [{TableSchema}.{TableName}]")]
    public class Table
    {
        [SchemaColumn("TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [SchemaColumn("TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [SchemaColumn("TABLE_NAME")]
        public string TableName { get; set; }

        [SchemaColumn("TABLE_TYPE")]
        public string TableType { get; set; }
    }
}
