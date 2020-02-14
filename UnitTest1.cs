using JsonValidation;
using Xunit;

namespace JsonValidationTests
{
    public class UnitTest1
    {
        [Fact]
        public void InvalidatesStringBecauseIsNotBorderedByQuotationMarks()
        {
            const string testCase = "testCase";
            Assert.False(Program.ValidateJsonString(testCase));
        }

        [Fact]

        public void InvalidateStringsBecauseIsBorderedOnlyOnLeftSide()
        {
            const string testCase = "\"testCase";
            Assert.False(Program.ValidateJsonString(testCase));
        }

        [Fact]

        public void InvalidatesStringBecauseIsBorderedOnlyOnRightSide()
        {
            const string testCase = "testCase\"";
            Assert.False(Program.ValidateJsonString(testCase));
        }

        [Fact]

        public void InvalidatesStringBecauseItContainsBackslashes()
        {
            const string testCase = "\"t\\estCase\"";
            Assert.False(Program.ValidateJsonString(testCase));
        }

        [Fact]

        public void InvalidatesStringBecauseItContainsQuotes()
        {
            const string testCase = "\"tes\"tCase\"";
            Assert.False(Program.ValidateJsonString(testCase));
        }

        [Fact]

        public void InvalidatesSingleCharacterStringContainingInvalidCharacter()
        {
            const string testCase = "\\";
            Assert.False(Program.ValidateJsonString(testCase));
        }

        [Fact]

        public void ValidatesSimpleCorrectJsonString()
        {
            const string testCase = "\"Test\"";
            Assert.True(Program.ValidateJsonString(testCase));
        }

        [Fact]
        public void CheckIfUnicode()
        {
            const string uni = "\\u0097";
            Assert.True(Program.CheckForUnicode(uni));
        }

        [Fact]

        public void ValidatesComplexCorrectJsonString()
        {
            const string testCase = "\"Test\\u0097\nAnother line\"";
            Assert.True(Program.ValidateJsonString(testCase));
        }
    }
}
