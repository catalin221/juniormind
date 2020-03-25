using Xunit;

namespace Range
{
    public class AnyTests
    {
        [Fact]
        public void ValidatesCorrectStringWithLowerCaseStart()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void ValidatesCorrectStringWithUpperCaseStart()
        {
            var e = new Any("eE");
            Assert.True(e.Match("Ea").Success());
            Assert.Equal("a", e.Match("Ea").RemainingText());
        }

        [Fact]
        public void InvalidatesStringWithNoIncludedStart()
        {
            var e = new Any("eE");
            Assert.False(e.Match("a").Success());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void InvalidatesEmptyString()
        {
            var e = new Any("");
            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void InvalidatesNullString()
        {
            var e = new Any(null);
            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void ValidatesCorrectStringWithPositiveSignedNumber()
        {
            var sign = new Any("+-");
            Assert.True(sign.Match("+3").Success());
            Assert.Equal("3", sign.Match("+3").RemainingText());
        }

        [Fact]
        public void ValidatesCorrectStringWithNegativeSignedNumber()
        {
            var sign = new Any("+-");
            Assert.True(sign.Match("-2").Success());
            Assert.Equal("2", sign.Match("-2").RemainingText());
        }

        [Fact]
        public void InvalidatesStringWithUnsignedNumber()
        {
            var sign = new Any("+-");
            Assert.False(sign.Match("2").Success());
            Assert.Equal("2", sign.Match("2").RemainingText());
        }
    }
}
