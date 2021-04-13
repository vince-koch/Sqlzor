using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlzor.Drivers.MySql
{
    public static class MySqlConverter
    {
        public static object ConvertStringToBool(object value)
        {
            switch (((string)value)?.ToLower())
            {
                case "yes":
                case "true":
                case "1":
                    return true;

                case "no":
                case "false":
                case "0":
                    return false;

                default:
                    throw new NotSupportedException($"{nameof(MySqlConverter)}.{nameof(ConvertStringToBool)} received unexpected value '{value}'");
            }
        }
    }
}
