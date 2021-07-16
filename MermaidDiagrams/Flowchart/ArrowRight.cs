namespace Flowchart
{
    public class ArrowRight : IFlowchartShape
    {
        private readonly int currentNode;
        private (int x, int y) coordinates;
        private (int width, int height) dimensions;

        public ArrowRight(int currentNode)
        {
            this.currentNode = currentNode;
            dimensions = (50, 10);
        }

        public string Draw()
        {
            (int x1, int y1, int x2, int y2) = (coordinates.x, coordinates.y, coordinates.x + dimensions.width, coordinates.y);
            dimensions.width += 10;
            return "<defs><marker id=\"endarrow\" markerWidth=\"10\" markerHeight=\"7\" refX=\"0\" refY=\"3.5\" orient=\"auto\">" +
                "<polygon points=\"0 0, 10 3.5, 0 7\" /></marker></defs>" +
                "<line x1=\"" + x1 + "\" y1=\"" + y1 + "\" x2=\"" + x2 + "\" y2=\"" + y2 + "\" " +
                "stroke=\"#000\" stroke-width=\"2\" marker-end =\"url(#endarrow)\" />";
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
            dimensions.width = currentNode * 50;
        }
    }
}
