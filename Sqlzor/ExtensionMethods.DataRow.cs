using System;
using System.Data;

namespace Sqlzor
{
    public static partial class ExtensionMethods
    {
        public static bool GetBool(this DataRow row, string columnName)
        {
            var value = (bool)row[columnName];
            return value;
        }

        public static DateTime GetDateTime(this DataRow row, string columnName)
        {
            var value = (DateTime)row[columnName];
            return value;
        }

        public static int GetInt(this DataRow row, string columnName)
        {
            var value = Convert.ToInt32(row[columnName]);
            return value;
        }

        public static long GetLong(this DataRow row, string columnName)
        {
            var value = Convert.ToInt64(row[columnName]);
            return value;
        }

        public static bool? GetNullableBool(this DataRow row, string columnName)
        {
            var value = row[columnName];
            if (value == DBNull.Value)
            {
                return (bool?)null;
            }

            return (bool)value;
        }

        public static int? GetNullableInt(this DataRow row, string columnName)
        {
            var value = row[columnName];
            if (value == DBNull.Value)
            {
                return (int?)null;
            }

            return Convert.ToInt32(value);
        }

        public static long? GetNullableLong(this DataRow row, string columnName)
        {
            var value = row[columnName];
            if (value == DBNull.Value)
            {
                return (long?)null;
            }

            return Convert.ToInt64(value);
        }

        public static short? GetNullableShort(this DataRow row, string columnName)
        {
            var value = row[columnName];
            if (value == DBNull.Value)
            {
                return (short?)null;
            }

            return Convert.ToInt16(value);
        }

        public static short GetShort(this DataRow row, string columnName)
        {
            var value = Convert.ToInt16(row[columnName]);
            return value;
        }

        public static string GetString(this DataRow row, string columnName)
        {
            var value = row[columnName];
            if (value == DBNull.Value)
            {
                return null;
            }

            return (string)value;
        }

        public static TValue GetValue<TValue>(this DataRow row, string columnName, Func<object, TValue> convert)
        {
            var value = row[columnName];
            var result = convert(value);
            return result;
        }
    }
}