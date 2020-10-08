using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public static class Program
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            TSource foundElement = default;
            bool found = false;
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    foundElement = element;
                    found = true;
                }

                if (found)
                {
                    break;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException();
            }

            return foundElement;
        }
    }
}
