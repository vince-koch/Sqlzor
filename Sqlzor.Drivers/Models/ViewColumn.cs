using System.Diagnostics;

namespace Sqlzor.Drivers.Models
{
    [DebuggerDisplay("ViewColumn [{ViewName}.{ViewColumn}]")]
    public class ViewColumn
    {
        public string ViewCatalog { get; set; }

        public string ViewSchema { get; set; }

        public string ViewName { get; set; }

        public string TableCatalog { get; set; }

        public string TableSchema { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }
    }
}
