/*
using System;
using System.Linq;
using System.Reflection;

namespace Sqlzor.DbSchema
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SchemaColumnAttribute : Attribute
    {
        public string ColumnName { get; }
        
        public string ProviderName { get; set; }

        public bool IsIgnored { get; set; } = false;

        public string Converter { get; set; }

        private Func<object, object> _converter = null;
        private bool _hasConverterBeenInitialized = false;

        public object Convert(object value)
        {
            if (!_hasConverterBeenInitialized)
            {
                _converter = BuildConverter();
                _hasConverterBeenInitialized = true;
            }

            if (_converter != null)
            {
                var converted = _converter(value);
                return converted;
            }

            return value;
        }

        private Func<object, object> BuildConverter()
        {
            if (string.IsNullOrWhiteSpace(Converter))
            {
                return null;
            }

            var index = Converter.LastIndexOf('.');
            var typeName = Converter.Substring(0, index);
            var methodName = Converter.Substring(index + 1);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .ToArray();

            var type = types
                .Where(type => type.FullName == typeName)
                .SingleOrDefault();

            if (type == null)
            {
                type = types
                    .Where(type => type.Name == typeName)
                    .Single();
            }

            var method = type.GetMethod(
                methodName,
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            Func<object, object> converted = (Func<object, object>)Delegate.CreateDelegate(typeof(Func<object, object>), method);

            return converted;
        }

        public SchemaColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
*/