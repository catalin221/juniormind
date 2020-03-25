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
            if (string.IsNullOrEmpty(text))
            {
                return (IMatch)new FailedMatch(text);
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (prefix[i] != text[i])
                {
                    return (IMatch)new FailedMatch(text);
                }
            }

            return (IMatch)new SuccesMatch(text.Substring(prefix.Length));
        }
    }
}
