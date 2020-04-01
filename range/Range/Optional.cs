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
            IMatch match = new SuccesMatch(pattern.Match(text).RemainingText());

            return pattern.Match(text).Success()
               ? match
               : new SuccesMatch(text);
        }
    }
}
