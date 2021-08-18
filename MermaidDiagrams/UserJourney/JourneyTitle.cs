using System;
using System.Collections.Generic;
using System.Text;

namespace UserJourney
{
    public class JourneyTitle : IUserJourney
    {
        private readonly string title;
        private (int x, int y) coordinates;
        private (int width, int height) dimensions;

        public JourneyTitle((int x, int y) coordinates, string title)
        {
            this.dimensions = (200, 50);
            this.title = title;
            this.coordinates = coordinates;
        }

        public string Draw()
        {
            return "<text x=\"" + coordinates.x + "\" y=\"" + coordinates.y + "\" font-size=\"35px\" font-weight=\"bold\" font-family=\"arial\">" + title + "<text>";
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }

        public (int width, int height) GetDimensions()
        {
            return dimensions;
        }
    }
}
