using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public static class EnumerableExtensions
    {
        public static void each<T>(this IEnumerable<T> all_items,Action<T> visitor)
        {
            new List<T>(all_items).ForEach(visitor);
        }
    }
}