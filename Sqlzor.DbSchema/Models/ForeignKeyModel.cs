using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("ForeignKey [{TableCatalog}.{TableSchema}.{TableName} {ConstraintName}]")]
    public class ForeignKeyModel
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string ConstraintName { get; set; }

        public string ReferencedTableCatalog { get; set; }

        public string ReferencedTableSchema { get; set; }

        public string ReferencedTableName { get; set; }

        public string ReferencedColumnName { get; set; }
    }
}
