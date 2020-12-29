using System;
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

        public static int ConvertToInt(string word)
        {
            ThrowNullException(word);
            bool negative = false;
            string newWord = RemoveSigns(word, ref negative);
            int positive = newWord.Aggregate(0, (sum, current) => sum * 10 + ConvertCharToInt(current));
            return negative ? -positive : positive;
        }

        private static int ConvertCharToInt(char character)
        {
            if (IsDigit(character))
            {
                return character - '0';
            }

            throw new InvalidOperationException("Format is not suitable for int conversion!");
        }

        private static bool IsDigit(char character)
        {
            return character >= '0' && character <= '9';
        }

        private static string RemoveSigns(string word, ref bool negative)
        {
            string withoutWhitespaces = RemoveWhitespaces(word);
            negative = withoutWhitespaces.StartsWith('-');
            return withoutWhitespaces.StartsWith('-') || withoutWhitespaces.StartsWith('+') ? withoutWhitespaces.Substring(1) : withoutWhitespaces;
        }

        private static string RemoveWhitespaces(string word) => new string(word.Where(element => element != ' ').ToArray());

        private static void ThrowNullException(string word)
        {
            if (word != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(word));
        }
    }
}
