namespace MermaidDiagrams
{
    public class StadiumNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public StadiumNode(string input)
        {
            text = input;
            dimensions = (50, 40);
        }

        public string Draw()
        {
            string textAtX = "\"" + (coordinates.x + 2) + "\"";
            string textAtY = "\"" + (coordinates.y + (dimensions.height / 2)) + "\"";
            const int round = 20;

            return "<rect width =\"" + dimensions.width + "\" height =\"" + dimensions.height + "\" x =\"" + coordinates.x + "\" y =\"" + coordinates.y + "\"" +
                   " rx= \"" + round + "\" ry =\"" + round + "\" style = \"fill:#e6fff7 ; stroke-width:1; stroke: rgb(0, 0, 0)\" />" +
                   "<text x =" + textAtX + " y=" + textAtY + " fill =\"black\" >" + text + "</text >";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }

        public void UpdateDimensions()
        {
            if (text.Length <= 5)
            {
                return;
            }

            dimensions.width += text.Length * 7;
        }
    }
}