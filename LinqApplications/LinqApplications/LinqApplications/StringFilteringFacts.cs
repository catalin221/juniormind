using Xunit;

namespace LinqApplications
{
    public class StringFilteringFacts
    {
        [Fact]
        public void CheckVowelsAndConsonantsNumber()
        {
            const string testWord = "abcdef";
            Assert.Equal((2, 4), StringFiltering.CountVowelsAndConsonants(testWord));
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
