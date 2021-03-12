using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidDiagrams
{
    public class RectangleNode : IFlowchartShape
    {
        private readonly string text;

        public RectangleNode(string input)
        {
            text = input;
        }

        public string Draw()
        {
            return "<rect width =\"150\" height =\"45\" x =\"1\" y =\"100\" " +
                   "style = \"fill:rgb(201, 219, 201) ; stroke-width:2; stroke: rgb(0, 0, 0)\" />" +
                   "<text x =\"25\" y=\"120\" fill =\"black\" >" + text + "</text >";
        }
    }
}
