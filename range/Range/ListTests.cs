using Xunit;

namespace Range
{
    public class ListTests
    {
        [Fact]
        public void ConsumesTextWithAllValidPatterns()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3").Success());
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void ConsumesTextPartiallyWithValidPatterns()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3,").Success());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
        }

        [Fact]

        public void ConsumesValidCharacterInText()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]

        public void DoesNotConsumeTextWithNoValidCharacter()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

        [Fact]

        public void ConsumesTextWithComplexPattern()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());
        }

        [Fact]

        public void ConsumesTextWIthComplexPatternPartially()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1 \n;").Success());
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());
        }

        [Fact]

        public void DoesNotConsumeTextWithComplexPattern()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("abc").Success());
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }

        [Fact]

        public void DoesNotConsumeNullTextWithComplexPattern()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match(null).Success());
            Assert.Null(list.Match(null).RemainingText());
        }

        [Fact]

        public void DoesNotConsumeEmptyTextWithComplexPattern()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("").Success());
            Assert.Equal("", list.Match("").RemainingText());
        }
    }
}
