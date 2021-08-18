namespace UserJourney
{
    public class ActionRectangle : IUserJourney
    {
        private readonly string action;
        private readonly string color;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public ActionRectangle(string action, string color)
        {
            this.color = color;
            this.action = action;
            this.dimensions = (150, 55);
        }

        public string Draw()
        {
            var rectangle = new SectionRectangle(action, color);
            rectangle.UpdateCoordinates(coordinates);
            (int x, int y) = (coordinates.x + (dimensions.width / 2), coordinates.y + dimensions.height);
            string dottedLine = "<line x1=\"" + x + "\" x2=\"" + x + "\" y1=\"" + y + "\" y2=\"" + (y + 270) +
                                "\" stroke=\"black\" stroke-dasharray=\"5,5\"/>";
            dimensions.height += 280;
            return rectangle.Draw() + dottedLine;
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public (int x, int y) GetCoordinates()
        {
            return coordinates;
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}