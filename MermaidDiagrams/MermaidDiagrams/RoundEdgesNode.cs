namespace MermaidDiagrams
{
    public class RoundEdgesNode : IFlowchartShape
    {
        private readonly string text;

        public RoundEdgesNode(string input)
        {
            text = input;
        }

        public string Draw()
        {
            return "<rect width =\"150\" height =\"45\" x =\"1\" y =\"100\" rx =\"10\" ry =\"5\" " +
                  "style = \"fill:rgb(201, 219, 201) ; stroke-width:2; stroke: rgb(0, 0, 0)\" />" +
                  "<text x =\"25\" y=\"120\" fill =\"black\" >" + text + "</text >";
        }
    }
}
