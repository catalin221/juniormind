using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidDiagrams
{
    public class CircleNode
    {
        private readonly string text;

        public CircleNode(string input)
        {
            text = input;
        }

        public string Draw()
        {
            return "<circle style = \"fill: rgb(216, 216, 216);\" cx = \"170\" cy = \"128\" r = \"50\" >" +
                "</ circle ><text x =\"25\" y=\"120\" fill =\"black\" >" + text + "</text >";
        }
    }
}
