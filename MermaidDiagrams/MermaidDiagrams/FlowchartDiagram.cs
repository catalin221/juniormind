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
            int width = 0;
            int height = 0;
            string namespaceAndDimensions = "<svg xmlns =\"http://www.w3.org/2000/svg\" width =" + width + " height = " + height + ">";
            const string svgEnd = "</svg>";
            string file = namespaceAndDimensions;

            foreach (var shape in shapes)
            {
                file += shape.Draw();
            }

            file += svgEnd;
            StreamWriter write = File.CreateText(path);
            write.Write(file);
            write.Close();
        }

        private void UpdateBackground(int width, int height)
        {

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
