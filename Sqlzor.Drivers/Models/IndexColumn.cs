using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("IndexColumn [{ConstraintName}.{ColumnName}]")]
    public class IndexColumn
    {
        public string ConstraintCatalog { get; set; }

        public string ConstraintSchema { get; set; }

        public string ConstraintName { get; set; }

        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public int OrdinalPostion { get; set; }

        public string IndexName { get; set; }
    }
}
