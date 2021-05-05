using System.Linq;

namespace MermaidDiagrams
{
    public class CircleNode : IFlowchartShape
    {
        private readonly string text;
        private int radius;
        private (int width, int height) dimensions;
        private (int x, int y) coordinates;

        public CircleNode(string input)
        {
            text = input;
            radius = 20;
            dimensions = (radius, radius);
        }

        public string Draw()
        {
            (int r, int cx, int cy) = (radius, coordinates.x + radius, coordinates.y);
            return "<circle cx = \"" + cx + "\" cy = \"" + cy + "\" r = \"" + r + "\" style=\"fill:#e6fff7; stroke: grey; stroke - width:1\"/>" +
                    "<text x =\"" + (coordinates.x + 10) + "\" y=\"" + cy + "\">" + text + "</text >";
        }

        public void UpdateDimensions()
        {
            if (text.Length <= 2)
            {
                return;
            }

            const int initialRadius = 20;
            radius += (text.Length / 2) * 8;
            dimensions = (radius + (2 * initialRadius), radius);
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }

        public (int width, int height) GetDimensions()
        {
            return dimensions;
        }
    }
}
