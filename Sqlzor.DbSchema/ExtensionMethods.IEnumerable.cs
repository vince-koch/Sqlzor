using System;
using System.Collections.Generic;

namespace Sqlzor.DbSchema
{
    public static partial class ExtensionMethods
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
