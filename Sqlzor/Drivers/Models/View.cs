using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("View [{TableCatalog}.{TableSchema}.{TableName}]")]
    public class View
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }
    }
}
