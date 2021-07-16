using System.Collections.Generic;
using System.Linq;

namespace Flowchart
{
    public class DrawLR : IOrientation
    {
        private readonly List<IFlowchartShape> shapes;
        private (int x, int y) coordinates;

        public DrawLR((int x, int y) coordinates, List<IFlowchartShape> shapes)
        {
            this.coordinates = coordinates;
            this.shapes = shapes;
        }

        public void Draw(ref string svg, (int width, int height) background)
        {
            UpdateBackground(shapes.First().GetDimensions().width, shapes.First().GetDimensions().height);
            foreach (var shape in shapes)
            {
                shape.UpdateCoordinates(coordinates);
                shape.UpdateDimensions();
                (int width, int height) = (coordinates.x + shape.GetDimensions().width + 100, coordinates.y + shape.GetDimensions().height + 100);
                UpdateBackground(width, height);
                svg += shape.Draw();
                UpdateCoordinates(shape.GetDimensions().width + 100, 0);
            }
        }

        public void UpdateBackground(int width, int height)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCoordinates(int toAddX, int toAddY)
        {
            throw new System.NotImplementedException();
        }
    }
}
