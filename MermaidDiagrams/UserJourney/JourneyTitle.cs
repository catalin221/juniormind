using System;
using System.Collections.Generic;
using System.Text;

namespace UserJourney
{
    public class JourneyTitle
    {
        private readonly string title;
        private (int x, int y) coordinates;

        public JourneyTitle((int x, int y) coordinates, string title)
        {
            this.title = title;
            this.coordinates = coordinates;
        }

        public string Draw()
        {
            return "<text x =\"" + coordinates.x + "y=\" + textAtY + " fill =\"black\" >" + text + "</text >";
        }

        public (int width, int height) GetDimensions()
        {
        }

        public void UpdateCoordinates((int x, int y) coordinates)
        {
            this.coordinates = coordinates;
        }

        public void UpdateDimensions()
        {
            if (text.Length <= 5)
            {
                return;
            }

            var dimension = dimensions.width + (text.Length * 3);
            dimensions = (dimension, dimension);
        }
    }
}
}
