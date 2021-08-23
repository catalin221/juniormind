namespace UserJourney
{
    public class SectionRectangle : IUserJourney
    {
        private readonly string action;
        private readonly (int width, int height) dimensions;
        private readonly string color;
        private (int x, int y) coordinates;

        public SectionRectangle(string action, string color)
        {
            this.color = color;
            this.action = action;
            this.dimensions = (150, 55);
        }

        public string Draw()
        {
            string rectangle = "<rect x=\"" + coordinates.x + "\" y=\"" + coordinates.y + "\" width=\"" + dimensions.width + "\" " +
                               "height=\"" + dimensions.height + "\" rx=\"3\" fill=\"rgb(" + color + ")\" />";
            string text = "<text x=\"" + (coordinates.x + (dimensions.width / 2)) + "\" y=\"" + (coordinates.y + (dimensions.height / 2)) + "\" dominant-baseline=\"middle\" " +
                          "text-anchor=\"middle\">" + action + "</text>";

            return rectangle + text;
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }

        public (int x, int y) GetCoordinates()
        {
            return coordinates;
        }
    }
}
