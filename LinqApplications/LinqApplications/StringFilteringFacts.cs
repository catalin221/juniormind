using Xunit;

namespace LinqApplications
{
    public class StringFilteringFacts
    {
        [Fact]
        public void CheckVowelsAndConsonantsNumber()
        {
            const string testWord = "abcdef";
            int vowels = 0;
            int consonants = 0;
            StringFiltering.CountVowelsAndConsonants(testWord, ref vowels, ref consonants);
            Assert.Equal((2, 4), (vowels, consonants));
        }

        [Fact]
        public void CheckFirstUniqueCharcaterInString()
        {
            const string testWord = "cbabcea";
            Assert.Equal('e', StringFiltering.FindFirstUniqueCharacter(testWord));
        }

        [Fact]
        public void CheckFirstUniqueCharcaterInStringWithOnlyUniqueCharacters()
        {
            const string testWord = "cbae";
            Assert.Equal('c', StringFiltering.FindFirstUniqueCharacter(testWord));
        }

        [Fact]
        public void CheckMostOccurenciesCharInString()
        {
            const string testWord = "cbeabcca";
            Assert.Equal('c', StringFiltering.FindCharacterWithMostOccurences(testWord));
        }
    }
}
