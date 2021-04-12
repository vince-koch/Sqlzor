using System.Diagnostics;

namespace Sqlzor.Data.Drivers.Models
{
    public static class Misc
    {
        public static int CastToInt(object value) => (int)value;
    }

    [DebuggerDisplay("Column [{TableName}.{ColumnName}]")]
    [SchemaTable("Columns")]
    public class Column
    {
        [SchemaColumn("TABLE_CATALOG")]
        public string TableCatalog { get; set; }

        [SchemaColumn("TABLE_SCHEMA")]
        public string TableSchema { get; set; }

        [SchemaColumn("TABLE_NAME")]
        public string TableName { get; set; }

        [SchemaColumn("COLUMN_NAME")]
        public string ColumnName { get; set; }

        [SchemaColumn("ORDINAL_POSITION", Converter = Misc.CastToInt, ProviderName = ProviderNames.MySql)]
        [SchemaColumn("ORDINAL_POSITION")]
        public int OrdinalPosition { get; set; }

        [SchemaColumn("COLUMN_DEFAULT")]
        public string ColumnDefault { get; set; }

        [SchemaColumn("IS_NULLABLE")]
        public bool IsNullable { get; set; }

        [SchemaColumn("DATA_TYPE")]
        public string DataType { get; set; }

        [SchemaColumn("CHARACTER_MAXIMUM_LENGTH")]
        public int CharacterMaximumLength { get; set; }
    }
}
