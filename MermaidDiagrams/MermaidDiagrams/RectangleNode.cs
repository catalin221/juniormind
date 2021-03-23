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

        public string Draw(int atX, int atY)
        {
            const string quote = "\"";
            return "<rect width =\"150\" height =\"50\" x =" + quote + atX + quote + " y =" + quote + atY + quote +
                    " style = \"fill:rgb(201, 219, 201) ; stroke-width:1; stroke: rgb(0, 0, 0)\" />" +
                   "<text x =" + quote + (atX + 2) + " y=" + quote + (atY + 10) + quote + " fill =\"black\" >" + text + "</text >";
        }
    }
}
