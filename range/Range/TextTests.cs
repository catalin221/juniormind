using Xunit;

namespace Range
{
    public class TextTests
    {
        [Fact]
        public void ValidatesStringContainingOnlyPrefix()
        {
            var truetext = new Text("true");
            Assert.True(truetext.Match("true").Success());
            Assert.Equal("", truetext.Match("true").RemainingText());
        }

        [Fact]
        public void ValidatesStringContainingPrefix()
        {
            var truetext = new Text("true");
            Assert.True(truetext.Match("trueX").Success());
            Assert.Equal("X", truetext.Match("trueX").RemainingText());
        }

        [Fact]
        public void InvalidatesStringWithoutGivenPrefix()
        {
            var truetext = new Text("true");
            Assert.False(truetext.Match("false").Success());
            Assert.Equal("false", truetext.Match("false").RemainingText());
        }

        [Fact]
        public void InvalidatesNullString()
        {
            var truetext = new Text("true");
            Assert.False(truetext.Match(null).Success());
            Assert.Null(truetext.Match(null).RemainingText());
        }

        [Fact]
        public void InvalidatesEmptyString()
        {
            var truetext = new Text("true");
            Assert.False(truetext.Match("").Success());
            Assert.Equal("", truetext.Match("").RemainingText());
        }

        [Fact]
        public void ValidatesStringWhenPrefixIsEmpty()
        {
            var truetext = new Text("");
            Assert.True(truetext.Match("true").Success());
            Assert.Equal("true", truetext.Match("true").RemainingText());
        }

        [Fact]
        public void InvalidatesNullStringWithEmptyPrefix()
        {
            var truetext = new Text("");
            Assert.False(truetext.Match(null).Success());
            Assert.Null(truetext.Match(null).RemainingText());
        }
    }
}
