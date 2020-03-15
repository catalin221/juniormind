using Xunit;

namespace Range
{
    public class ChoiceTests
    {
        [Fact]
        public void ValidatesStringStartingWithSpecifiedChar()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void ValidatesStringBeginningWithStartOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("12"));
        }

        [Fact]
        public void ValidatesStringBeginningWithEndOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("92"));
        }

        [Fact]
        public void InvalidatesEmptyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void InvalidatesNullString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(digit.Match(null));
        }

        [Fact]

        public void ValidatesHexStringWithLowerCaseStartingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("a9"));
        }

        [Fact]

        public void ValidatesHexStringWithUpperCaseStartingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("A9"));
        }

        [Fact]

        public void InvalidatesHexStringWithLowerCaseOutOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match("g9"));
        }

        [Fact]

        public void InvalidatesHexStringWithUpperCaseOutOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match("G9"));
        }

        [Fact]

        public void ValidatesHexStringWithUpperCaseEndingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("F9"));
        }

        [Fact]

        public void ValidatesHexStringWithLowerCaseEndingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("f9"));
        }
    }
}
