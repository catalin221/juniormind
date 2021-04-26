namespace MermaidDiagrams
{
    public class CylinderNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;

        public CylinderNode(string input)
        {
            text = input;
            dimensions = (50, 100);
        }

        public string Draw(int atX, int atY)
        {
            (int x1, int y1, int x2, int y2) = (atX, atY, atX, atY + dimensions.height);
            (int x1, int y1, int x2, int y2) secondLine = (atX + dimensions.width, atY, atX + dimensions.width, atY + dimensions.height);

            (double ry, int rx, int cy, int cx) = (5 + (2.5 * (dimensions.width / 50)), (secondLine.x1 - x1) / 2,
                                                                atY, (x1 + secondLine.x1) / 2);
            (double ry, int rx, int cy, int cx) bottomEllipse = (ry, rx, atY + dimensions.height, cx);

            (int x, int y, int width, int height) rectangle = (atX, atY, dimensions.width, dimensions.height);
            int textAt = atY + (dimensions.height / 2);

            string firstLineString = "<line x1=\"" + x1 + "\" y1=\"" + y1 + "\" x2=\"" +
                x2 + "\" y2=\"" + y2 + "\" style=\"stroke:grey;stroke-width:3\" />";
            string secondLineString = "<line x1=\"" + secondLine.x1 + "\" y1=\"" + secondLine.y1 + "\" x2=\"" +
                secondLine.x2 + "\" y2=\"" + secondLine.y2 + "\" style=\"stroke:grey;stroke-width:3\" />";
            string bottomEllipseString = "<ellipse cx=\"" + bottomEllipse.cx + "\" cy=\"" + bottomEllipse.cy + "\" " +
                "rx=\"" + bottomEllipse.rx + "\" ry=\"" + bottomEllipse.ry + "\" style=\"fill:#e6fff7;stroke:grey;stroke-width:2\" />";
            string topEllipseString = "<ellipse cx=\"" + cx + "\" cy=\"" + cy + "\" " +
                "rx=\"" + rx + "\" ry=\"" + ry + "\" style=\"fill:#e6fff7;stroke:grey;stroke-width:2\" />";
            string rectangleString = "<rect x=\"" + rectangle.x + "\" y=\"" + rectangle.y + "\"  width=\"" + rectangle.width + "\" " +
                "height=\"" + rectangle.height + "\" style=\"fill:#e6fff7; stroke-width:2; stroke:null\" />";
            string textString = "<text x=\"" + (atX + 10) + "\" y=\"" + textAt + "\">" + text + "</text>";

            return firstLineString + secondLineString + bottomEllipseString + rectangleString + topEllipseString + textString;
        }

        public (int width, int height) GetDimensions()
        {
            return dimensions;
        }

        public void UpdateDimensions()
        {
            if (text.Length <= 5)
            {
                return;
            }

            dimensions.width = text.Length * 8;
        }
    }
}
