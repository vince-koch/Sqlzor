using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("IndexColumn [{IndexName}.{ColumnName}]")]
    public class IndexColumnModel
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string IndexName { get; set; }

        public string ColumnName { get; set; }

        public int? OrdinalPostion { get; set; }
    }
}
