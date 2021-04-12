using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("ForeignKeys")]
    [DebuggerDisplay("ForeignKey [{ConstraintCatalog}.{ConstraintSchema}.{ConstraintName}]")]
    public class ForeignKey
    {
        [SchemaColumn("CONSTRAINT_CATALOG")]
        public string ConstraintCatalog { get; set; }

        [SchemaColumn("CONSTRAINT_SCHEMA")]
        public string ConstraintSchema { get; set; }

        [SchemaColumn("CONSTRAINT_NAME")]
        public string ConstraintName { get; set; }

        [SchemaColumn("TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [SchemaColumn("TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [SchemaColumn("TABLE_NAME")]
        public string TableName { get; set; }
    }
}
