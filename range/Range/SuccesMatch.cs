namespace Range
{
    public class SuccesMatch : IMatch
    {
        private readonly string text;

        public SuccesMatch(string text)
        {
            this.text = text;
        }

        public bool Success()
        {
            return true;
        }

        public string RemainingText()
        {
            return text;
        }
    }
}