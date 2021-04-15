using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("View [{TableCatalog}.{TableSchema}.{TableName}]")]
    public class ViewModel
    {
        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }
    }
}
