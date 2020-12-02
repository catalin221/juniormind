using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public class StringFiltering
    {
        public static void CountVowelsAndConsonants(string word, ref int vowelsCount, ref int consonantsCount)
        {
            vowelsCount = word.Aggregate(0, (vowels, current) => "aeiouAEIOU".Contains(current) ? vowels + 1 : vowels);
            consonantsCount = word.Aggregate(0, (consonants, current) => "aeiouAEIOU".Contains(current) ? consonants : consonants + 1);
        }

        public static char FindFirstUniqueCharacter(string word)
        {
            return word.GroupBy(x => x).First(element => element.Count() == 1).Key;
        }

        public static char FindCharacterWithMostOccurences(string word)
        {
            return word.GroupBy(element => element).Aggregate((max, element) => element.Count() > max.Count() ? element : max).Key;
        }
    }
}
