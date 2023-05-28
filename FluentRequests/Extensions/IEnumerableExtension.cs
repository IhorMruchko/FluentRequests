using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.Extensions
{
    public static class IEnumerableExtension
    {
        public static int IndexOf<TElements>(IEnumerable<TElements> source, Predicate<TElements> selector)
        {
            for (var i = 0; i < source.Count(); ++i)
            {
                if (selector(source.ElementAt(i)))
                    return i;
            }
            return -1;
        }
    }
}
