using Xunit;

namespace LinqApplications
{
    public class ReversePolishNotationFacts
    {
        [Fact]
        public void CalculateReversePolishNotationForSimpleExpression()
        {
            Assert.Equal(5, ReversePolishNotation.CalculateExpression("7 5 - 3 +"));
        }

        [Fact]
        public void CalculateReversePolishNotationForComplexExpression()
        {
            Assert.Equal(5, ReversePolishNotation.CalculateExpression("15 7 1 1 + - / 3 * 2 1 1 + + -"));
        }
    }
}
