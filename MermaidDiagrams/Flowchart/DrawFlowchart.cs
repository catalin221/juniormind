using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Flowchart
{
    public class DrawFlowchart
    {
        private readonly string orientation;
        private readonly List<IFlowchartShape> shapes;
        private IOrientation drawOrientation;
        private (int width, int height) background;
        private (int x, int y) coordinates;

        public DrawFlowchart(List<IFlowchartShape> shapes, string orientation)
        {
            this.shapes = shapes;
            this.orientation = orientation;
            this.coordinates = (50, 100);
            this.background = (shapes.First().GetDimensions().width, shapes.First().GetDimensions().height);
        }

        public void Draw(string path)
        {
            ThrowNullException(shapes);
            SetOrientation();
            string temp = "";
            drawOrientation.Draw(ref temp, background);
            string file = "<svg width =\"" + background.width + "\" height =\"" + background.height + "\">" + temp + "</svg>";
            StreamWriter write = File.CreateText(path);
            write.Write(file);
            write.Close();
        }

        private void SetOrientation()
        {
            switch (orientation)
            {
                case "LR":
                    drawOrientation = new DrawLR(coordinates, shapes);
                    break;
                case "RL":
                    drawOrientation = new DrawRL(coordinates, shapes);
                    break;
                case "TB":
                    drawOrientation = new DrawTB(coordinates, shapes);
                    break;
                case "BT":
                    drawOrientation = new DrawBT(coordinates, shapes);
                    break;
            }
        }

        private void ThrowNullException(List<IFlowchartShape> argument)
        {
            if (argument != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(argument));
        }
    }
}
