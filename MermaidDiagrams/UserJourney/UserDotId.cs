namespace UserJourney
{
    public class UserDotId : IUserJourney
    {
        private readonly string color;
        private readonly string id;
        private readonly (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public UserDotId(string id, string color)
        {
            this.id = id;
            this.color = color;
        }

        public string Draw()
        {
            (int x, int y) textCoord = (coordinates.x + 20, coordinates.y + 5);
            return "<circle cx=\"" + coordinates.x + "\" cy=\"" + coordinates.y + "\" r=\"7\" stroke=\"black\" stroke-width=\"1\" fill=\"rgb(" + color + ")\" /> " +
                "<text x=\"" + textCoord.x + "\" y=\"" + textCoord.y + "\" font-size=\"14\">" + id + "</text>\"";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public string GetId()
        {
            return this.id;
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