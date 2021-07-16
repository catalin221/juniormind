namespace UserJourney
{
    public class SmileyFace : IUserJourney
    {
        private readonly (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public SmileyFace()
        {
            this.dimensions = (15, 15);
        }

        public string Draw()
        {
            string face = "<circle cx=\"" + coordinates.x + "\" cy=\"" + coordinates.y + "\" r=\"15\" " +
                "stroke=\"grey\" stroke-width=\"2\" fill=\"rgb(249, 255, 140)\" />";
            string leftEye = "<circle cx=\"" + (coordinates.x - 5) + "\" cy=\"" + (coordinates.y - 5) + "\" r=\"2\" stroke=\"grey\" stroke-width=\"2\" fill=\"grey\" />";
            string rightEye = "<circle cx=\"" + (coordinates.x + 5) + "\" cy=\"" + (coordinates.y - 5) + "\" r=\"2\" stroke=\"grey\" stroke-width=\"2\" fill=\"grey\" />";
            (int dx, int dy, int x1, int y1, int x2, int y2, int x, int y) = (coordinates.x - 5, coordinates.y + 5, coordinates.x - 5, coordinates.y + 10,
                                                                             coordinates.x + 5, coordinates.y + 10, coordinates.x + 5, coordinates.y + 5);
            string mouth = "<path d=\"M " + dx + ' ' + dy + ',' + " C " + x1 + ' ' + y1 + ',' + x2 + ' ' + y2 + ',' + x + ' ' + y + "\" " +
                "stroke-width=\"2\" stroke=\"grey\" fill=\"transparent\"/>";

            return face + leftEye + rightEye + mouth;
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
