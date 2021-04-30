using System;
using System.Collections.Generic;

namespace MermaidDiagrams
{
    public class DrawDiagrams
    {
        public static void Main()
        {
            List<IFlowchartShape> shapes = new List<IFlowchartShape>
            {
                new CircleNode("TEXT for circle node"),
                new RectangleNode("Text for rectangle node"),
                new CylinderNode("Text for a cylinder node"),
                new RoundEdgesNode("Text for round edges node"),
                new StadiumNode("Text for stadium shaped node"),
                new SubroutineNode("TEXT for subroutine node"),
                new ParalelogramNode("Text for paralelogram node"),
                new AltParalelogramNode("Text for AltParalelogram node"),
                new AssymetricNode("Text for Assymetric node")
            };
            Console.WriteLine("Please input path");
            var flowchart = new FlowchartDiagram(shapes, "LR");
            flowchart.DrawFlowchart(Console.ReadLine());
            Console.WriteLine("File created");
        }
    }
}
