using Xunit;

namespace Range
{
    public class OneOrMoreTests
    {
        [Fact]

        public void ValidatesPatternWithMoreCharsInRange()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("123").Success());
            Assert.Equal("", a.Match("123").RemainingText());
        }

        [Fact]

        public void ValidatesPatternWithOneCharInRange()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void InvalidatesPatternWithNoCharInRange()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void InvalidatesNullString()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void InvalidatesEmpty()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }
    }
}
