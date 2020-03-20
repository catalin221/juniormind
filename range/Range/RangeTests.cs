using Xunit;

namespace Range
{
    public class RangeTests
    {
        [Fact]
        public void ValidatesTextBeginningWithStartOfRange()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("abc").Success());
        }

        [Fact]

        public void ValidatesTextBeginningWithEndOfRange()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("fab").Success());
        }

        [Fact]

        public void ValidatesTextBeginningWithLetterWithinRange()
        {
            var digit = new Range('a', 'f');
            Assert.True(digit.Match("bcd").Success());
        }

        [Fact]
        public void InvalidatesTextBeginningWithCharacterOutsideRange()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("1ab").Success());
        }

        [Fact]
        public void InvalidatesNullText()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match(null).Success());
        }

        [Fact]

        public void InvalidatesEmptyText()
        {
            var digit = new Range('a', 'f');
            Assert.False(digit.Match("").Success());
        }
    }
}
