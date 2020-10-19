using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var item in source)
            {
                foreach(var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
                    this IEnumerable<TSource> source,
                    Func<TSource, TKey> keySelector,
                    Func<TSource, TElement> elementSelector)
        {
            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();
            foreach (var element in source)
            {
                dictionary.Add(keySelector(element), elementSelector(element));
            }

            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
                    this IEnumerable<TFirst> first,
                    IEnumerable<TSecond> second,
                    Func<TFirst, TSecond, TResult> resultSelector)
        {
            var firstElement = first.GetEnumerator();
            var secondElement = second.GetEnumerator();

            while (firstElement.MoveNext() && secondElement.MoveNext())
            {
                yield return resultSelector(firstElement.Current, secondElement.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
                    this IEnumerable<TSource> source,
                    TAccumulate seed,
                    Func<TAccumulate, TSource, TAccumulate> func)
        {
            TAccumulate result = seed;
            foreach (var element in source)
            {
                result = func(result, element);
            }

            return result;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
                    this IEnumerable<TOuter> outer,
                    IEnumerable<TInner> inner,
                    Func<TOuter, TKey> outerKeySelector,
                    Func<TInner, TKey> innerKeySelector,
                    Func<TOuter, TInner, TResult> resultSelector)
        {
            foreach (var element in outer)
            {
                foreach (var innerElement in inner)
                {
                    if (innerKeySelector(innerElement).Equals(outerKeySelector(element)))
                    {
                        yield return resultSelector(element, innerElement);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
                    this IEnumerable<TSource> source,
                    IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> notAdded = new HashSet<TSource>(comparer);
            foreach (var item in source)
            {
                if (notAdded.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> notAdded = new HashSet<TSource>(comparer);
            foreach (var element in first)
            {
                if (notAdded.Add(element))
                {
                    yield return element;
                }
            }

            foreach (var element in second)
            {
                if (notAdded.Add(element))
                {
                    yield return element;
                }
            }



        }

    }
}
