using Xunit;
using System;

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

        [Fact]
        public void ConvertsNumberWithWhitespaces()
        {
            const string testWord = "10 000";
            Assert.Equal(10000, StringFiltering.ConvertToInt(testWord));
        }

        [Fact]
        public void ConvertsNumberWithSign()
        {
            const string testWord = "-10 000";
            Assert.Equal(-10000, StringFiltering.ConvertToInt(testWord));
        }

        [Fact]
        public void ConvertsNumberWithWhitespacesAndSign()
        {
            const string testWord = "+10 0 0 0";
            Assert.Equal(10000, StringFiltering.ConvertToInt(testWord));
        }

        [Fact]
        public void DoesNotConvertNumberWithTwoSigns()
        {
            const string testWord = "+-10000";
            Assert.Throws<InvalidOperationException>(() => StringFiltering.ConvertToInt(testWord));
        }

        [Fact]
        public void DoesNotConvertNumberWithLetters()
        {
            const string testWord = "10000b";
            Assert.Throws<InvalidOperationException>(() => StringFiltering.ConvertToInt(testWord));
        }

        [Fact]
        public void DoesNotConvertNumberWithTwoSignsReversed()
        {
            const string testWord = "-+10000";
            Assert.Throws<InvalidOperationException>(() => StringFiltering.ConvertToInt(testWord));
        }
    }
}
