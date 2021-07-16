namespace Flowchart
{
    public interface IOrientation
    {
        public void Draw(ref string svg, (int width, int height) background);

        public void UpdateBackground(int width, int height);

        public void UpdateCoordinates(int toAddX, int toAddY);
    }
}
