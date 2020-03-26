using Xunit;

namespace Range
{
    public class OptionalTests
    {
        [Fact]
        public void ConsumesPatternWithOneCharacter()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]

        public void ConsumesOneCharacterPatternWithTwoIdenticalCharactersInText()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]

        public void DoesNotConsumePatternWhenNotInText()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void DoesNotConsumePatternInEmptyText()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void DoesNotConsumePatternInNullText()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void ConsumesSignInTextContainingSignedNumber()
        {
            var sign = new Optional(new Character('-'));
            Assert.True(sign.Match("-123").Success());
            Assert.Equal("123", sign.Match("123").RemainingText());
        }

        [Fact]
        public void DoesNotConsumeSignInTextWithUnsignedNumber()
        {
            var sign = new Optional(new Character('-'));
            Assert.True(sign.Match("123").Success());
            Assert.Equal("123", sign.Match("123").RemainingText());
        }
    }
}
