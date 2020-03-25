namespace Range
{
    class Any : IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || accepted.IndexOf(text[0]) == -1
               ? new FailedMatch(text)
               : (IMatch)new SuccesMatch(text.Substring(1));
        }
    }
}
