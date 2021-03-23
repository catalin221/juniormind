namespace MermaidDiagrams
{
    public class BasicNode : IFlowchartShape
    {
        private readonly string id;

        public BasicNode(string input)
        {
            id = input;
        }

        public string Draw(int atX, int atY)
        {
            const string quote = "\"";
            return "<rect width =\"40\" height =\"50\" x =" + quote + atX + quote + " y =" + quote + atY + quote +
                "style = \"fill:rgb(195, 236, 168) ; stroke-width:2; stroke: rgb(0, 0, 0)\" /> " +
                "<text x =" + quote + (atX + 2) + " y=" + quote + (atY + 10) + quote + " fill =\"black\" >" + text + "</text >";
        }
    }
}
