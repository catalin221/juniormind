namespace Flowchart
{
    public class AssymetricNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public AssymetricNode(string input)
        {
            text = input;
            dimensions = (60, 40);
        }

        public string Draw()
        {
            string textAtX = "\"" + (coordinates.x + 30) + "\"";
            string textAtY = "\"" + (coordinates.y + (dimensions.height / 2)) + "\"";
            int middle = coordinates.y + (dimensions.height / 2);
            string pointA = coordinates.x.ToString() + ',' + coordinates.y.ToString();
            string pointB = (coordinates.x + dimensions.width).ToString() + ',' + coordinates.y.ToString() + ' ';
            string pointC = (coordinates.x + dimensions.width).ToString() + ',' + (coordinates.y + dimensions.height).ToString() + ' ';
            string pointD = coordinates.x.ToString() + ',' + (coordinates.y + dimensions.height).ToString() + ' ';
            string pointE = (coordinates.x + 25).ToString() + ',' + middle.ToString() + ' ';
            string pointF = pointA;

            return "<polyline points=\"" + pointA + ' ' + pointB + pointC + pointD + pointE + pointF + "\" style=\"fill:#e6fff7;stroke:black;stroke-width:1\" />" +
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