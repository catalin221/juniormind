namespace MermaidDiagrams
{
    public class RhombusNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public RhombusNode(string input)
        {
            text = input;
            dimensions = (30, 30);
        }

        public string Draw()
        {
            string textAtX = "\"" + (coordinates.x + 20) + "\"";
            string textAtY = "\"" + coordinates.y + "\"";
            int middle = coordinates.y + (dimensions.height / 2);
            string pointA = coordinates.x.ToString() + ',' + coordinates.y.ToString();
            string pointB = (coordinates.x + dimensions.width).ToString() + ',' + (coordinates.y + dimensions.width).ToString() + ' ';
            string pointC = (coordinates.x + (2 * dimensions.width)).ToString() + ',' + coordinates.y.ToString() + ' ';
            string pointD = (coordinates.x + dimensions.width).ToString() + ',' + (coordinates.y - dimensions.width).ToString() + ' ';
            string pointE = pointA;
            var newDimensions = dimensions.width * 2;
            dimensions = (newDimensions, newDimensions);

            return "<polyline points=\"" + pointA + ' ' + pointB + pointC + pointD + pointE + "\" style=\"fill:#e6fff7;stroke:black;stroke-width:1\" />" +
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

            var dimension = dimensions.width + (text.Length * 3);
            dimensions = (dimension, dimension);
        }
    }
}