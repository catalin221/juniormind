namespace Range
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digits = new Many(new Range('0', '9'));
            var signs = new Any("+-");
            var exponents = new Any("eE");
            var integerSide = new Sequence(new Optional(new Character('-')), new Sequence(digits));
            var exponentSide = new Optional(new Sequence(exponents, new Optional(signs), new Range('1', '9')));
            var rationalSide = new Optional(new Sequence(new Character('.'), digits));
            pattern = new Sequence(integerSide, rationalSide, exponentSide);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
