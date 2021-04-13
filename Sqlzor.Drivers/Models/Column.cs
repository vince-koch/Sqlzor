using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("Column [{TableName}.{ColumnName}]")]
    public class Column
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public int OrdinalPosition { get; set; }

        public string ColumnDefault { get; set; }

        public bool IsNullable { get; set; }

        public string DataType { get; set; }

        public int CharacterMaximumLength { get; set; }
    }
}
