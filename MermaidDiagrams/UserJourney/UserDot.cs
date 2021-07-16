namespace UserJourney
{
    public class UserDot : IUserJourney
    {
        private readonly string color;
        private readonly string id;
        private readonly (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public UserDot(string id, string color)
        {
            this.id = id;
            this.color = color;
        }

        public string Draw()
        {
            (int x, int y) textCoord = (coordinates.x + 20, coordinates.y + 5);
            return "<circle cx=\"" + coordinates.x + "\" cy=\"" + textCoord.y + "\" r=\"7\" stroke=\"black\" stroke-width=\"1\" fill=\"(" + color + ")\" /> " +
                "<text x=\"" + textCoord.x + "\" y=\"" + textCoord.y + "\" font-size=\"14\">" + id + "</text>\"";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
