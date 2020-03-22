using Xunit;

namespace Range
{
    public class ChoiceTests
    {
        [Fact]
        public void ValidatesStringStartingWithSpecifiedChar()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("012").Success());
            Assert.Equal("12", digit.Match("012").RemainingText());
        }

        [Fact]
        public void ValidatesStringBeginningWithStartOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("12").Success());
            Assert.Equal("12", digit.Match("012").RemainingText());
        }

        [Fact]
        public void ValidatesStringBeginningWithEndOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(digit.Match("92").Success());
            Assert.Equal("2", digit.Match("92").RemainingText());
        }

        [Fact]
        public void InvalidatesEmptyString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(digit.Match("").Success());
            Assert.Equal("", digit.Match("").RemainingText());
        }

        [Fact]
        public void InvalidatesNullString()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(digit.Match(null).Success());
            Assert.Null(digit.Match(null).RemainingText());
        }

        [Fact]

        public void ValidatesHexStringWithLowerCaseStartingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("a9").Success());
            Assert.Equal("9", hex.Match("a9").RemainingText());
        }

        [Fact]

        public void ValidatesHexStringWithUpperCaseStartingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("A9").Success());
            Assert.Equal("9", hex.Match("A9").RemainingText());
        }

        [Fact]

        public void InvalidatesHexStringWithLowerCaseOutOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match("g9").Success());
            Assert.Equal("g9", hex.Match("g9").RemainingText());
        }

        [Fact]

        public void InvalidatesHexStringWithUpperCaseOutOfRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match("G9").Success());
            Assert.Equal("G9", hex.Match("G9").RemainingText());
        }

        [Fact]

        public void ValidatesHexStringWithUpperCaseEndingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("F9").Success());
            Assert.Equal("9", hex.Match("F9").RemainingText());
        }

        [Fact]

        public void ValidatesHexStringWithLowerCaseEndingRange()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("f9").Success());
            Assert.Equal("9", hex.Match("f9").RemainingText());
        }
    }
}
