using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MermaidDiagrams
{
    public class FlowchartDiagram
    {
        private readonly string orientation;
        private readonly List<IFlowchartShape> shapes;
        private (int width, int height) background;
        private (int x, int y) coordinates;

        public FlowchartDiagram(List<IFlowchartShape> shapes, string orientation)
        {
            this.shapes = shapes;
            this.orientation = orientation;
            this.coordinates = (0, 100);
            this.background = (shapes.First().GetDimensions().width, shapes.First().GetDimensions().height);
        }

        public void DrawFlowchart(string path)
        {
            ThrowNullException(shapes);
            string temp = "";

            foreach (var shape in shapes)
            {
                shape.UpdateDimensions();
                var toAddX = coordinates.x + shape.GetDimensions().width;
                var toAddY = coordinates.y + shape.GetDimensions().height;
                UpdateBackground(toAddX, toAddY);
                temp += shape.Draw(coordinates.x, coordinates.y);

                UpdateCoordinates(shape.GetDimensions().width + 100, 0);
            }

            string namespaceAndDimension = "<svg xmlns =\"http://www.w3.org/2000/svg\" width =\"" + background.width + "\" height =\"" + background.height + "\">";
            string file = namespaceAndDimension + temp + "</svg>";
            StreamWriter write = File.CreateText(path);
            write.Write(file);
            write.Close();
        }

        private void UpdateBackground(int toAddX, int toAddY)
        {
            background.width += toAddX;
            background.height += toAddY;
        }

        private void UpdateCoordinates(int toAddX, int toAddY)
        {
            coordinates = (coordinates.x + toAddX, coordinates.y + toAddY);
        }

        private void ThrowNullException(List<IFlowchartShape> argument)
        {
            if (argument != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(argument));
        }
    }
}
