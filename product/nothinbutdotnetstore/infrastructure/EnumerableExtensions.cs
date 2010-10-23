using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    public static class EnumerableExtensions
    {
        public static void each<T>(this IEnumerable<T> all_items,Action<T> visitor)
        {
            new List<T>(all_items).ForEach(visitor);
        }

        public static IEnumerable<Output> map_all_using<T, Output>(this IEnumerable<T> items,
                                                                   Mapper<T, Output> mapper)
        {
            return items.Select(x => mapper.map_from(x));
        }

        public static IEnumerable<Output> map_all_using<T, Output,Mapper>(this IEnumerable<T> items) where Mapper : infrastructure.Mapper<T,Output>,new()
        {
            return items.Select(x => new Mapper().map_from(x));
        }
    }
}