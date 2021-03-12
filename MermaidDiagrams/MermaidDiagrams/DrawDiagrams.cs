using System;
using System.Collections.Generic;

namespace MermaidDiagrams
{
    public class DrawDiagrams
    {
        public static void Main()
        {
            List<IFlowchartShape> shapes = new List<IFlowchartShape> { new RectangleNode("TextSecondNode") };
            Console.WriteLine("Please input path");
            FlowchartDiagram.DrawFlowchart(shapes, Console.ReadLine());
            Console.WriteLine("File created");
        }
    }
}
