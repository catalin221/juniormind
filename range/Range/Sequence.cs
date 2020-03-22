namespace Range
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return (IMatch)new FailedMatch(text);
            }

            string initialText = text;

            SuccesMatch success = new SuccesMatch(text);
            for (int i = 0; i < patterns.Length; i++)
            {
                IMatch match = patterns[i].Match(text);
                if (!match.Success())
                {
                    return new FailedMatch(initialText);
                }

                success = new SuccesMatch(match.RemainingText());
                text = match.RemainingText();
            }

            return (IMatch)success;
        }
    }
}
