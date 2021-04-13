using System;

namespace Sqlzor.Drivers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SchemaTableAttribute : Attribute
    {
        public string TableName { get; }

        public string ProviderName { get; }

        public SchemaTableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
