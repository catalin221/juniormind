using Xunit;

namespace Range
{
    public class NumberTests
    {
        [Fact]
        public void ValidatesUnsignedIntegerNumber()
        {
            var number = new Number();
            Assert.True(number.Match("1234").Success());
            Assert.Equal("", number.Match("1234").RemainingText());
        }

        [Fact]
        public void ValidatesUnsignedZeroStartingIntegerNumber()
        {
            var number = new Number();
            Assert.True(number.Match("01234").Success());
            Assert.Equal("", number.Match("01234").RemainingText());
        }

        [Fact]
        public void ValidatesSignedIntegerNumber()
        {
            var number = new Number();
            Assert.True(number.Match("-1234").Success());
            Assert.Equal("", number.Match("-1234").RemainingText());
        }

        [Fact]
        public void ValidatesUnsignedRationalNumber()
        {
            var number = new Number();
            Assert.True(number.Match("1.234").Success());
            Assert.Equal("", number.Match("1.234").RemainingText());
        }

        [Fact]
        public void ValidatesSignedRationalNumber()
        {
            var number = new Number();
            Assert.True(number.Match("-1.234").Success());
            Assert.Equal("", number.Match("-1.234").RemainingText());
        }

        [Fact]
        public void ValidatesIncompleteExponentialFormatNumber()
        {
            var number = new Number();
            Assert.True(number.Match("12.123E").Success());
            Assert.Equal("E", number.Match("12.123E").RemainingText());
        }

        [Fact]
        public void ValidatesIncompleteRationalNumber()
        {
            var number = new Number();
            Assert.True(number.Match("123.").Success());
            Assert.Equal("", number.Match("123.").RemainingText());
        }

        [Fact]
        public void ValidatesLowerCasePositiveExponentNumber()
        {
            var number = new Number();
            Assert.True(number.Match("123.12e+1").Success());
            Assert.Equal("", number.Match("123.12e+1").RemainingText());
        }

        [Fact]
        public void ValidatesUpperCasePositiveExponentNumber()
        {
            var number = new Number();
            Assert.True(number.Match("123.12E+1").Success());
            Assert.Equal("", number.Match("123.12E+1").RemainingText());
        }

        [Fact]
        public void ValidatesLowerCaseNegativeExponentNumber()
        {
            var number = new Number();
            Assert.True(number.Match("123.12e-1").Success());
            Assert.Equal("", number.Match("123.12e-1").RemainingText());
        }

        [Fact]
        public void ValidatesUpperCaseNegativeExponentNumber()
        {
            var number = new Number();
            Assert.True(number.Match("123.12E-1").Success());
            Assert.Equal("", number.Match("123.12E-1").RemainingText());
        }
    }
}
