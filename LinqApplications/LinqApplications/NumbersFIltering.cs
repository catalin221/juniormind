using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public static class NumbersFiltering
    {
        public static IEnumerable<IEnumerable<int>> GetSubsetsOfSpecificSum(IEnumerable<int> source, int maxSum)
        {
            int count = source.Count();
            return source.SelectMany((x, index) => source.Skip(index)
            .Select((number, secondIndex) => source
            .Skip(secondIndex).Take(count - secondIndex - index))
             .Where(x => x.Sum() <= maxSum));
        }

        public static IEnumerable<string> GenerateSumSets(int maxNumber, int numberToCheck)
        {
            return Enumerable.Range(1, maxNumber)
                 .Aggregate((IEnumerable<string>)new[] { "" }, (x, _) =>
                     x.SelectMany(result => new[] { result + "+", result + "-" }))
               .Where(x => GetSum(x) == numberToCheck)
                   .Select(element => string.Concat(element.Select((letter, i) => letter.ToString() + (i + 1)))
                   + string.Concat(" = ", numberToCheck.ToString()));
        }

        public static IEnumerable<IEnumerable<int>> GeneratePythagoreanTriples(IEnumerable<int> array)
        {
            ThrowNullException(array);
            return array.SelectSkip((x, inner) =>
                inner.SelectSkip((y, result) =>
                result.SelectMany(z => GetTriplePermutations(x, y, z))));
        }

        private static bool IsPythagoreanTriple(int firstElement, int secondElement, int thirdElement)
        {
            return (firstElement * firstElement) + (secondElement * secondElement)
                     == thirdElement * thirdElement;
        }

        private static IEnumerable<IEnumerable<int>> GetTriplePermutations(int first, int second, int third)
        {
            return CreateEnumerable(first, second, third)
                   .Where(x => IsPythagoreanTriple(x.First(), x.ElementAt(1), x.Last()));
        }

        private static IEnumerable<IEnumerable<int>> CreateEnumerable(int first, int second, int third)
        {
            return new[]
            {
                new[] { first, second, third }, new[] { first, third, second },
                new[] { second, first, third }, new[] { second, third, first },
                new[] { third, first, second }, new[] { third, second, first }
            };
        }

        private static IEnumerable<TSource> SelectSkip<TSource>(this IEnumerable<int> source, Func<int, IEnumerable<int>, IEnumerable<TSource>> func)
        {
            return source.SelectMany((a, i) =>
            {
                var inner = source.Skip(i + 1);
                return func(a, inner);
            });
        }

        private static int GetSum(string source)
        {
            return Enumerable.Range(0, source.Length)
                .Aggregate(0, (x, y) => source[y] == '+' ? x + 1 + y : x - 1 - y);
        }

        private static void ThrowNullException(IEnumerable<int> source)
        {
            if (source != null)
            {
                return;
            }

            throw new ArgumentNullException("source");
        }
    }
}
