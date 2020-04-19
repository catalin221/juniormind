using Xunit;

namespace Range
{
    public class StringTests
    {
        [Fact]
        public void InvalidatesStringBecauseIsNotBorderedByQuotationMarks()
        {
            StringValue testCase = new StringValue();
            Assert.False(testCase.Match("testCase").Success());
            Assert.Equal("testCase", testCase.Match("testCase").RemainingText());
        }

        [Fact]

        public void InvalidateStringsBecauseIsBorderedOnlyOnLeftSide()
        {
            StringValue testCase = new StringValue();
            Assert.False(testCase.Match("\"testCase").Success());
            Assert.Equal("\"testCase", testCase.Match("\"testCase").RemainingText());
        }

        [Fact]

        public void InvalidatesStringBecauseIsBorderedOnlyOnRightSide()
        {
            StringValue testCase = new StringValue();
            Assert.False(testCase.Match("testCase\"").Success());
            Assert.Equal("testCase\"", testCase.Match("testCase\"").RemainingText());
        }

        [Fact]

        public void ValidatesStringOnlyWithBorders()
        {
            StringValue testCase = new StringValue();
            Assert.True(testCase.Match("\"\"").Success());
            Assert.Equal("", testCase.Match("\"\"").RemainingText());
        }

        [Fact]

        public void InvalidatesStringBecauseItContainsEscapeCharacter()
        {
            StringValue testCase = new StringValue();
            Assert.False(testCase.Match("\"t\\estCase\"").Success());
            Assert.Equal("\"t\\estCase\"", testCase.Match("\"t\\estCase\"").RemainingText());
        }

        [Fact]

        public void ValidatesStringWithQuotes()
        {
            StringValue testCase = new StringValue();
            Assert.True(testCase.Match("\"Te\"st\"").Success());
            Assert.Equal("st\"", testCase.Match("\"Te\"st\"").RemainingText());
        }

        [Fact]

        public void InvalidatesStringContainingBackslash()
        {
            StringValue testCase = new StringValue();
            Assert.False(testCase.Match("\\").Success());
            Assert.Equal("\\", testCase.Match("\\").RemainingText());
        }

        [Fact]

        public void ValidatesSimpleCorrectJsonString()
        {
            StringValue testCase = new StringValue();
            Assert.True(testCase.Match("\"Test\"").Success());
            Assert.Equal("", testCase.Match("\"Test\"").RemainingText());
        }

        [Fact]

        public void ValidatesComplexCorrectJsonString()
        {
            StringValue testCase = new StringValue();
            Assert.True(testCase.Match("\"Test\\u0097\\nAnother line\"").Success());
            Assert.Equal("", testCase.Match("\"Test\\u0097\\nAnother line\"").RemainingText());
        }

        [Fact]
        public void ValidatesStringWithExceptedCase()
        {
            StringValue testCase = new StringValue();
            Assert.True(testCase.Match("\"test\\\"case\"").Success());
            Assert.Equal("", testCase.Match("\"test\\\"case\"").RemainingText());
        }
    }
}
