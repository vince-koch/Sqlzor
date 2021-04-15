using System;

namespace Sqlzor.Data
{
    public static partial class ExtensionMethods
    {
        public static string ToHumanTimeString(this TimeSpan? span, int significantDigits = 3)
        {
            return span.HasValue
                ? ToHumanTimeString(span.Value, significantDigits)
                : string.Empty;
        }

        public static string ToHumanTimeString(this TimeSpan span, int significantDigits = 3)
        {
            var format = "G" + significantDigits;

            if (span.TotalMilliseconds < 1000)
            {
                return span.TotalMilliseconds.ToString(format) + " milliseconds";
            }
            else if (span.TotalSeconds < 60)
            {
                return span.TotalSeconds.ToString(format) + " seconds";
            }
            else if (span.TotalMinutes < 60)
            {
                return span.TotalMinutes.ToString(format) + " minutes";
            }
            else if (span.TotalHours < 24)
            {
                return span.TotalHours.ToString(format) + " hours";
            }
            else
            {
                return span.TotalDays.ToString(format) + " days";
            }
        }
    }
}
