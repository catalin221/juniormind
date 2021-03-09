using System;
using System.Collections.Generic;
using System.IO;

namespace MermaidDiagrams
{
    public static class FlowchartDiagram
    {
        public static void DrawFlowchart(List<IFlowchartShape> shapes, string path)
        {
            ThrowNullException(shapes);
            const string namespaceAndDimensions = "<svg xmlns =\"http://www.w3.org/2000/svg\" width =\"1920\" height =\"1080\">";
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
