using Xunit;

namespace JsonNumberValidation
{
    public class UnitTest1
    {
        [Fact]
        public void ValidatesUnsignedIntegerNumber()
        {
            Assert.True(Program.ValidateJsonNumber("234"));
        }

        [Fact]

        public void ValidatesNegativeIntegerNumber()
        {
            Assert.True(Program.ValidateJsonNumber("-234"));
        }

        [Fact]

        public void ValidateRationalNumber()
        {
            Assert.True(Program.ValidateJsonNumber("12.34"));
        }

        [Fact]

        public void ValidatesNumberWithExponent()
        {
            Assert.True(Program.ValidateJsonNumber("12.123e3"));
        }

        [Fact]

        public void ValidatesNumberWithExponentFollowedByAddingExpression()
        {
            Assert.True(Program.ValidateJsonNumber("12.123E+3"));
        }

        [Fact]

        public void ValidatesNumberWithExponentFollowedBySubtraction()
        {
            Assert.True(Program.ValidateJsonNumber("12.123E-2"));
        }

        [Fact]

        public void InvalidatesNumberWithWrongExponentFormat()
        {
            Assert.False(Program.ValidateJsonNumber("12.123E"));
        }

        [Fact]

        public void InvalidatesZeroPrefixedNumber()
        {
            Assert.False(Program.ValidateJsonNumber("012"));
        }

        [Fact]

        public void InvalidatesNumberWithWrongFormat()
        {
            Assert.False(Program.ValidateJsonNumber("12."));
        }
    }
}
