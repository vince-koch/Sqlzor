using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("IndexColumns")]
    [DebuggerDisplay("IndexColumn [{ConstraintName}.{ColumnName}]")]
    public class IndexColumn
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

        [SchemaColumn("COLUMN_NAME")]
        public string ColumnName { get; set; }

        [SchemaColumn("ORDINAL_POSITION")]
        public int OrdinalPostion { get; set; }

        [SchemaColumn("INDEX_NAME")]
        public string IndexName { get; set; }
    }
}
