namespace UserJourney
{
    public class Arrow : IUserJourney
    {
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public Arrow(int length)
        {
            this.dimensions = (length, 10);
        }

        public string Draw()
        {
            const string marker = "<defs><marker id=\"arrowhead\" markerWidth=\"10\" markerHeight=\"5\" " +
                            "refX=\"0\" refY=\"2.5\" orient=\"auto\"><polygon points=\"0 0, 10 2.5, 0 5\" /></marker></defs>";
            string line = "<line x1=\"" + coordinates.x + "\" y1=\"" + coordinates.y + "\" x2=\"" + (coordinates.x + dimensions.width) +
                          "\" y2=\"" + coordinates.y + "\" stroke=\"#000\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\" />";
            dimensions.width += 15;

            return marker + line;
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
