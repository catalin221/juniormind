﻿using Flowchart;
using UserJourney;
using System;
using System.Collections.Generic;

namespace DrawMermaid
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
                new RoundCornersNode("Text for round edges node"),
                new StadiumNode("Text for stadium shaped node"),
                new SubroutineNode("TEXT for subroutine node"),
                new ParalelogramNode("Text for paralelogram node"),
                new AltParalelogramNode("Text for AltParalelogram node"),
                new AssymetricNode("Text for Assymetric node"),
                new RhombusNode("Text for rhombus node"),
                new HexagonNode("Text for hexa node"),
                new TrapezoidNode("text for Trapezoid node"),
                new AltTrapezoidNode("Text for AltTrapezoid node")
            };
            Console.WriteLine("Please input path");
            var flowchart = new DrawFlowchart(shapes, "LR");
            flowchart.Draw(Console.ReadLine());
            Console.WriteLine("File created");
        }
    }
}
