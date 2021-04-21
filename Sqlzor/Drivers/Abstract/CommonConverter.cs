using System;

namespace Sqlzor.Drivers.Abstract
{
    public static class CommonConverter
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
                    throw new NotSupportedException($"{nameof(CommonConverter)}.{nameof(ConvertStringToBool)} received unexpected value '{value}'");
            }
        }
    }
}
