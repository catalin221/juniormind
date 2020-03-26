namespace Range
{
    class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || prefix != text.Substring(0, prefix.Length)
                ? (IMatch)new FailedMatch(text)
                : new SuccesMatch(text.Substring(prefix.Length));
        }
    }
}
