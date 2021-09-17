using System.Diagnostics;

namespace Sqlzor.DbSchema.Models
{
    [DebuggerDisplay("Table [{TableSchema}.{TableName}]")]
    public class TableModel
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string TableType { get; set; }
    }
}
