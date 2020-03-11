using Xunit;

namespace Range
{
    public class RangeTests
    {
        [Fact]
        public void ValidatesTextBeginningWithStartOfRange()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc"));
        }

        [Fact]

        public void ValidatesTextBeginningWithEndOfRange()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("fab"));
        }

        [Fact]

        public void ValidatesTextBeginningWithLetterWithinRange()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("bcd"));
        }

        [Fact]
        public void InvalidatesTextBeginningWithCharacterOutsideRange()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1ab"));
        }

        [Fact]
        public void InvalidatesNullText()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(null));
        }

        [Fact]

        public void InvalidatesEmptyText()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(""));
        }
    }
}
