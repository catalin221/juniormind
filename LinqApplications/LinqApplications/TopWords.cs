using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public static class TopWords
    {
        public static IEnumerable<string> GetTopWords(string input, int topWords)
        {
            ThrowNullException(input);
            return input.Split(new[] { ' ', '.', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(x => x.ToLower()).OrderByDescending(x => x.Count())
                .Select(x => string.Join(" - ", x.Key, x.Count().ToString())).Take(topWords);
        }

        private static void ThrowNullException(string source)
        {
            if (source != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(source));
        }
    }
}