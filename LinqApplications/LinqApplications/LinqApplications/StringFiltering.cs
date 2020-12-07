using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public class StringFiltering
    {
        public static (int consonants, int vowels) CountVowelsAndConsonants(string word)
        {
            return word.Aggregate((0, 0), (tuple, current) => "aeiouAEIOU".Contains(current)
            ? (tuple.Item1 + 1, tuple.Item2)
            : (tuple.Item1, tuple.Item2 + 1));
        }

        public static char FindFirstUniqueCharacter(string word)
        {
            return word.GroupBy(x => x).First(element => element.Count() == 1).Key;
        }

        public static char FindCharacterWithMostOccurences(string word)
        {
            return word.GroupBy(element => element)
                .Select(element => (element, element.Count()))
                .Aggregate((max, element) => element.Item2 > max.Item2 ? element : max).element.Key;
        }
    }
}
