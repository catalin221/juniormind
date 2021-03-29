using System;
using System.Collections.Generic;
using System.IO;

namespace MermaidDiagrams
{
    public static class FlowchartDiagram
    {
        public static void DrawFlowchart(List<IFlowchartShape> shapes, string path, string orientation)
        {
            ThrowNullException(shapes);
            var coordinates = (x: 0, y: 0);
            var dimension = (width: 0, height: 0);
            string width = "\"" + dimension.width + "\"";
            string height = "\"" + dimension.height + "\"";
            string temp = "";

            foreach (var shape in shapes)
            {
                shape.UpdateDimensions();
                var toAddX = coordinates.x + shape.GetDimensions().width;
                var toAddY = coordinates.y + shape.GetDimensions().height;
                UpdateBackground(dimension, toAddX, toAddY);
                temp += shape.Draw(coordinates.x, coordinates.y);
            }

            string namespaceAndDimension = "<svg xmlns =\"http://www.w3.org/2000/svg\" width =" + width + " height = " + height + ">";
            string file = namespaceAndDimension + temp + "</svg>";
            StreamWriter write = File.CreateText(path);
            write.Write(file);
            write.Close();
        }

        private static void UpdateBackground((int width, int height) toUpdate, int toAddX, int toAddY)
        {
            toUpdate.width += toAddX;
            toUpdate.height += toAddY;
        }

        private static void ThrowNullException(List<IFlowchartShape> argument)
        {
            if (argument != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(argument));
        }
    }
}
