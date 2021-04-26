namespace MermaidDiagrams
{
    public class ParalelogramNode : IFlowchartShape
    {
        private readonly string text;
        private (int width, int height) dimensions;

        public ParalelogramNode(string input)
        {
            text = input;
            dimensions = (50, 40);
        }

        public string Draw(int atX, int atY)
        {
            string textAtX = "\"" + (atX - 45) + "\"";
            string textAtY = "\"" + (atY + (dimensions.height / 2)) + "\"";

            return "<rect width =\"" + dimensions.width + "\" height =\"" + dimensions.height + "\" x =\"" + atX + "\" y =\"" + atY + "\"" +
                   "  transform=\"skewX(-25)\" style = \"fill:#e6fff7 ; stroke-width:1; stroke: rgb(0, 0, 0)\" />" +
                   "<text x =" + textAtX + " y=" + textAtY + " fill =\"black\" >" + text + "</text >";
        }

        public (int width, int height) GetDimensions()
        {
            return (dimensions.width, dimensions.height);
        }

        public void UpdateDimensions()
        {
            dimensions.width = text.Length * 7;
        }
    }
}