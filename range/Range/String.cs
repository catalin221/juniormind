namespace Range
{
    public class StringValue : IPattern
    {
        private readonly IPattern pattern;

        public StringValue()
        {
            var border = new Character('\"');
            var letterOrDigit = new Choice(
               new Range('a', 'f'),
               new Range('A', 'F'),
               new Range('0', '9'));

            var hex = new Sequence(
               new Character('u'),
               letterOrDigit,
               letterOrDigit,
               letterOrDigit,
               letterOrDigit);

            var acceptedCarriage = new Choice(
                new Any("\"\\\\bfnrt/"),
                hex);

            var posibility = new Optional(new OneOrMore(new Choice(
                new Range('\u0020', '\u0021'),
                new Range('\u0023', '\u005b'),
                new Range('\u005d', (char)ushort.MaxValue),
                new Sequence(new Character('\\'), acceptedCarriage))));
            pattern = new Sequence(
                border,
                posibility,
                border);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
