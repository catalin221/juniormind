namespace MermaidDiagrams
{
    public class AssymetricNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;

        public AssymetricNode(string input)
        {
            text = input;
            dimensions = (60, 40);
        }

        public string Draw(int atX, int atY)
        {
            string textAtX = "\"" + (atX + 30) + "\"";
            string textAtY = "\"" + (atY + (dimensions.height / 2)) + "\"";
            int middle = atY + (dimensions.height / 2);
            string pointA = atX.ToString() + ',' + atY.ToString();
            string pointB = (atX + dimensions.width).ToString() + ',' + atY.ToString() + ' ';
            string pointC = (atX + dimensions.width).ToString() + ',' + (atY + dimensions.height).ToString() + ' ';
            string pointD = atX.ToString() + ',' + (atY + dimensions.height).ToString() + ' ';
            string pointE = (atX + 25).ToString() + ',' + middle.ToString() + ' ';
            string pointF = pointA;

            return "<polyline points=\"" + pointA + ' ' + pointB + pointC + pointD + pointE + pointF + "\" style=\"fill:#e6fff7;stroke:black;stroke-width:1\" />" +
                   "<text x =" + textAtX + " y=" + textAtY + " fill =\"black\" >" + text + "</text >";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
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