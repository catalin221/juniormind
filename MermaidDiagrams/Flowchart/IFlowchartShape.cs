namespace Flowchart
{
    public interface IFlowchartShape
    {
        public string Draw();

        public (int width, int height) GetDimensions();

        public void UpdateDimensions();

        public void UpdateCoordinates((int x, int y) coordinates);
    }
}
