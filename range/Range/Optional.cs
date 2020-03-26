namespace Range
{
    class Optional : IPattern
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text).Success()
               ? (IMatch)new SuccesMatch(text.Substring(1))
               : new SuccesMatch(text);
        }
    }
}
