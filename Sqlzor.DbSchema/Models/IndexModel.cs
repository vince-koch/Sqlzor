using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("Index [{ConstraintCatalog}.{ConstraintSchema}.{ConstraintName}]")]
    public class IndexModel
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string IndexName { get; set; }

        public bool? IsPrimary { get; set; }

        public bool? IsUnique { get; set; }

        public bool? IsClustered { get; set; }
    }
}
