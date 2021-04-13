using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("Table [{TableSchema}.{TableName}]")]
    public class Table
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string TableType { get; set; }
    }
}
