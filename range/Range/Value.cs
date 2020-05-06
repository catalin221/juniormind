namespace Range
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
                        new StringValue(),
                        new Number(),
                        new Text("true"),
                        new Text("false"),
                        new Text("null"));

            var whitespace = new Optional(new OneOrMore(new Any(" \r\n\t")));
            var leftSquareBracket = new Character('[');
            var rightSquareBracket = new Character(']');
            var leftBracket = new Character('{');
            var rightBracket = new Character('}');
            var colon = new Character(':');
            var separator = new Sequence(whitespace, new Character(','), whitespace);
            var element = new Sequence(whitespace, value, whitespace);
            var member = new Sequence(whitespace, new StringValue(), whitespace, colon, element);
            var array = new Sequence(leftSquareBracket, new List(element, separator), rightSquareBracket);
            var jsonObject = new Sequence(leftBracket, new List(member, separator), rightBracket);

            value.Add(array);
            value.Add(jsonObject);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
