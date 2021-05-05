namespace MermaidDiagrams
{
    public class HexagonNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public HexagonNode(string input)
        {
            text = input;
            dimensions = (50, 40);
        }

        public string Draw()
        {
            string textAtX = "\"" + (coordinates.x + 5) + "\"";
            string textAtY = "\"" + (coordinates.y + (dimensions.height / 2)) + "\"";
            string pointA = coordinates.x.ToString() + ',' + coordinates.y.ToString();
            string pointB = (coordinates.x + dimensions.width).ToString() + ',' + coordinates.y.ToString() + ' ';
            string pointC = (coordinates.x + dimensions.width + 25).ToString() + ',' + (coordinates.y + (dimensions.height / 2)).ToString() + ' ';
            string pointD = (coordinates.x + dimensions.width).ToString() + ',' + (coordinates.y + dimensions.height).ToString() + ' ';
            string pointE = coordinates.x.ToString() + ',' + (coordinates.y + dimensions.height).ToString() + ' ';
            string pointF = (coordinates.x - 25).ToString() + ',' + (coordinates.y + (dimensions.height / 2)).ToString() + ' ';
            string pointG = pointA;

            return "<polyline points=\"" + pointA + ' ' + pointB + pointC + pointD + pointE + pointF + pointG +
                   "\" style=\"fill:#e6fff7;stroke:black;stroke-width:1\" />" +
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

            dimensions.width += text.Length * 5;
        }
    }
}