using Xunit;
using System.Collections.Generic;

namespace LinqApplications
{
    public class TopWordsFacts
    {
        [Fact]
        public void GetTopWordsReturnsMostUsedWords()
        {
            const string testText = "string split splits a string";
            Assert.Equal(new List<string> { "string - 2", "split - 1" }, TopWords.GetTopWords(testText, 2));
        }

        [Fact]
        public void GetTopWordsKeepsOrderForSingularElements()
        {
            const string testText = "string split splits a";
            Assert.Equal(new List<string> { "string - 1", "split - 1", "splits - 1", "a - 1" }, TopWords.GetTopWords(testText, 4));
        }

        [Fact]
        public void GetTopWordsSplitsBySeparatorsCorrectly()
        {
            const string testText = "string. split, splits; a";
            Assert.Equal(new List<string> { "string - 1", "split - 1", "splits - 1", "a - 1" }, TopWords.GetTopWords(testText, 4));
        }
    }
}
