using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    [SchemaTable("Indexes")]
    [DebuggerDisplay("Index [{ConstraintCatalog}.{ConstraintSchema}.{ConstraintName}]")]
    public class Index
    {
        [SchemaColumn("INDEX_CATALOG", ProviderName = ProviderNames.SQLite)]
        [SchemaColumn("CONSTRAINT_CATALOG")]
        public string ConstraintCatalog { get; set; }

        [SchemaColumn("INDEX_SCHEMA", ProviderName = ProviderNames.SQLite)]
        [SchemaColumn("CONSTRAINT_SCHEMA")]
        public string ConstraintSchema { get; set; }

        [SchemaColumn("INDEX_NAME", ProviderName = ProviderNames.SQLite)]
        [SchemaColumn("CONSTRAINT_NAME")]
        public string ConstraintName { get; set; }

        [SchemaColumn("TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [SchemaColumn("TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [SchemaColumn("TABLE_NAME")]
        public string TableName { get; set; }

        [SchemaColumn("INDEX_NAME", IsIgnored = true, ProviderName = ProviderNames.SQLite)]
        [SchemaColumn("INDEX_NAME")]
        public string IndexName { get; set; }
    }
}
