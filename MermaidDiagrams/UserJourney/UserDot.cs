namespace UserJourney
{
    public class UserDot : IUserJourney
    {
        private readonly string color;
        private readonly (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public UserDot(string color)
        {
            this.color = color;
        }

        public string Draw()
        {
            return "<circle cx=\"" + coordinates.x + "\" cy=\"" + coordinates.y + "\" r=\"7\" stroke=\"black\" stroke-width=\"1\" fill=\"(" + color + ")\" /> ";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public string GetColor()
        {
            return this.color;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
