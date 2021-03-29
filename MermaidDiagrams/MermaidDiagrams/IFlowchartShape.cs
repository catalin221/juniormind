namespace MermaidDiagrams
{
    public interface IFlowchartShape
    {
        public string Draw(int atX, int atY);

        public (int width, int height) GetDimensions();

        public void UpdateDimensions();
    }
}
