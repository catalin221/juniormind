namespace Range
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return (IMatch)new SuccesMatch(text);
            }

            IMatch match = new SuccesMatch(text);
            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
            }

            return (IMatch)new SuccesMatch(match.RemainingText());
        }
    }
}
