namespace Range
{
    class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || text[0] != pattern
               ? new FailedMatch(text)
               : (IMatch)new SuccesMatch(text.Substring(1));
        }
    }
}
