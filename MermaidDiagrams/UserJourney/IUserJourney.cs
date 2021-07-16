namespace UserJourney
{
    public interface IUserJourney
    {
        public string Draw();

        public (int width, int height) GetDimensions();

        public void UpdateCoordinates((int x, int y) coordinates);
    }
}
