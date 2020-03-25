using Xunit;

namespace Range
{
    public class ManyTests
    {
        [Fact]
        public void ConsumesOneOccurenceOfPatternInText()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void ConsumesAllOccurencesOfPatternInText()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void DoesNotConsumePatternWhenNotInText()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void DoesNotConsumePatternInEmptyText()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void DoesNotConsumePatternInNullText()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void ConsumesMultipleCharactersInRange()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void DoesNotConsumeAnyCharacterBecauseNoneIsInRange()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.True(digits.Match("ab").Success());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }
    }
}
