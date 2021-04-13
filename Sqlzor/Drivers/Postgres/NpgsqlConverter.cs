using System;

namespace Sqlzor.Drivers.Postgres
{
    public static class NpgsqlConverter
    {
        public static bool ConvertStringToBool(object value)
        {
            switch (value.ToString().ToLower())
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
                    throw new NotSupportedException($"{nameof(NpgsqlConverter)}.{nameof(ConvertStringToBool)} received unexpected value '{value}'");
            }
        }
    }
}
