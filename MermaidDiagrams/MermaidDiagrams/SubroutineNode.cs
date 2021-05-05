namespace MermaidDiagrams
{
    public class SubroutineNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public SubroutineNode(string input)
        {
            text = input;
            dimensions = (50, 40);
        }

        public string Draw()
        {
            string textAtX = "\"" + (coordinates.x + 15) + "\"";
            string textAtY = "\"" + (coordinates.y + (dimensions.height / 2)) + "\"";

            return "<rect width =\"" + dimensions.width + "\" height =\"" + dimensions.height + "\" x =\"" + coordinates.x + "\" y =\"" + coordinates.y + "\"" +
                   " style = \"fill:#e6fff7 ; stroke-width:1; stroke: rgb(0, 0, 0)\" />" +
                   "<line x1=\"" + (coordinates.x + 10) + "\" y1=\"" + coordinates.y +
                   "\" y2=\"" + (coordinates.y + dimensions.height) + "\" x2=\"" + (coordinates.x + 10) + "\" style=\"stroke:grey;stroke-width:2\"/>" +
                   "<line x1=\"" + (coordinates.x + dimensions.width - 10) + "\" y1=\"" + coordinates.y + "\" y2=\"" + (coordinates.y + dimensions.height) +
                   "\" x2=\"" + (coordinates.x + dimensions.width - 10) + "\" style=\"stroke:grey;stroke-width:2\"/>" +
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

            dimensions.width += text.Length * 8;
        }
    }
}