namespace Range
{
    class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return (IMatch)new FailedMatch(text);
            }

            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(text);
                if (match.Success())
                {
                    return match;
                }
            }

            return new FailedMatch(text);
        }

        public void Add(IPattern pattern)
        {
            IPattern[] newPatterns = new IPattern[patterns.Length + 1];
            for (int i = 0; i < patterns.Length; i++)
            {
                newPatterns[i] = patterns[i];
            }

            newPatterns[newPatterns.Length - 1] = pattern;
            patterns = newPatterns;
        }
    }
}
