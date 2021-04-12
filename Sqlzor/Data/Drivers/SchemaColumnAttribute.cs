using System;

namespace Sqlzor.Data.Drivers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SchemaColumnAttribute : Attribute
    {
        public string ColumnName { get; }
        
        public string ProviderName { get; set; }

        public bool IsIgnored { get; set; } = false;

        public Func<object, object> Converter { get; set; }

        public SchemaColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
