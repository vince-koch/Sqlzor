using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("ViewColumns")]
    [DebuggerDisplay("ViewColumn [{ViewName}.{ViewColumn}]")]
    public class ViewColumn
    {
        [SchemaColumn("VIEW_CATALOG")]
        public string ViewCatalog { get; set; }

        [SchemaColumn("VIEW_SCHEMA")]
        public string ViewSchema { get; set; }

        [SchemaColumn("VIEW_NAME")]
        public string ViewName { get; set; }

        [SchemaColumn("TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [SchemaColumn("TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [SchemaColumn("TABLE_NAME")]
        public string TableName { get; set; }

        [SchemaColumn("COLUMN_NAME")]
        public string ColumnName { get; set; }
    }
}
