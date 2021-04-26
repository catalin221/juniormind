namespace MermaidDiagrams
{
    public class SubroutineNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;

        public SubroutineNode(string input)
        {
            text = input;
            dimensions = (50, 40);
        }

        public string Draw(int atX, int atY)
        {
            string textAtX = "\"" + (atX + 15) + "\"";
            string textAtY = "\"" + (atY + (dimensions.height / 2)) + "\"";

            return "<rect width =\"" + dimensions.width + "\" height =\"" + dimensions.height + "\" x =\"" + atX + "\" y =\"" + atY + "\"" +
                   " style = \"fill:#e6fff7 ; stroke-width:1; stroke: rgb(0, 0, 0)\" />" +
                   "<line x1=\"" + (atX + 10) + "\" y1=\"" + atY + "\" y2=\"" + (atY + dimensions.height) + "\" x2=\"" + (atX + 10) + "\" style=\"stroke:grey;stroke-width:2\"/>" +
                   "<line x1=\"" + (atX + dimensions.width - 10) + "\" y1=\"" + atY + "\" y2=\"" + (atY + dimensions.height) +
                   "\" x2=\"" + (atX + dimensions.width - 10) + "\" style=\"stroke:grey;stroke-width:2\"/>" +
                   "<text x =" + textAtX + " y=" + textAtY + " fill =\"black\" >" + text + "</text >";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public void UpdateDimensions()
        {
            dimensions.width = text.Length * 8;
        }
    }
}