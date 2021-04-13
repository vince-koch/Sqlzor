using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("ForeignKey [{ConstraintCatalog}.{ConstraintSchema}.{ConstraintName}]")]
    public class ForeignKey
    {
        public string ConstraintCatalog { get; set; }

        public string ConstraintSchema { get; set; }

        public string ConstraintName { get; set; }

        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }
    }
}
