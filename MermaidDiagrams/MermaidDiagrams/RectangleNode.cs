using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidDiagrams
{
    public class RectangleNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;

        public RectangleNode(string input)
        {
            text = input;
            dimensions.width = 50;
            dimensions.height = 40;
        }

        public string Draw(int atX, int atY)
        {
            string textAtX = "\"" + atX + dimensions.width + 2 + "\"";
            string textAtY = "\"" + (atY + dimensions.height) / 2 + "\"";

            return "<rect width =\"" + dimensions.width + "\" height =\"" + dimensions.height + "\" x =\"" + atX + "\" y =\"" + atY +
                    " style = \"fill:rgb(201, 219, 201) ; stroke-width:1; stroke: rgb(0, 0, 0)\" />" +
                   "<text x =" + textAtX + " y=" + textAtY + " fill =\"black\" >" + text + "</text >";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public void UpdateDimensions()
        {
            dimensions.width = text.Length * 10;
        }
    }
}
