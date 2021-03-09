namespace MermaidDiagrams
{
    public class BasicNode : IFlowchartShape
    {
        private readonly string id;

        public BasicNode(string input)
        {
            id = input;
        }

        public string Draw()
        {
            const string rectangle = "<rect width =\"70\" height =\"40\" x =\"1\" y =\"100\" " +
                                     "style = \"fill:rgb(195, 236, 168) ; stroke-width:2; stroke: rgb(0, 0, 0)\" />";
            string text = "<text x =\"25\" y=\"120\" fill =\"black\" >" + id + "</text >";
            return rectangle + text;
        }
    }
}
