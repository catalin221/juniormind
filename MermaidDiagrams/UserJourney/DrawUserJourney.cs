﻿using System.Collections.Generic;
using System.Text;

namespace UserJourney
{
    public class DrawUserJourney
    {
        readonly Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        readonly Dictionary<int, int> scoreHeight;
        (int horizontalTitle, int verticalTitle) titleCoords;
        (int horizontalSection, int verticalSection) sectionCoords;
        (int horizontalAction, int verticalAction) actionCoords;
        (int horizontalArrow, int verticalArrow) arrowCoords;
        (int width, int height) background = (0, 0);

        public DrawUserJourney(Dictionary<string, List<(string actionName, int score, List<string> users)>> sections)
        {
            this.sections = sections;
            titleCoords = (150, 80);
            sectionCoords = (titleCoords.horizontalTitle, titleCoords.verticalTitle + 20);
            actionCoords = (titleCoords.horizontalTitle, sectionCoords.verticalSection + 10);
            arrowCoords = (titleCoords.horizontalTitle, actionCoords.verticalAction + 20);
            scoreHeight = new Dictionary<int, int> { { 5, 40 }, { 3, 80 }, { 1, 120 } };
        }

        public void DrawJourney()
        {
            string[] rectangleColors = new[]
            {
                "230, 104, 50", "230, 149, 50", "242, 219, 87", "230, 252, 81", "164, 250, 15", "25, 29, 255", "121, 58, 240",
                "138, 65, 217", "171, 65, 217", "199, 65, 217", "217, 65, 194", "217, 65, 113", "217, 65, 65"
            };

            string[] userDotColors = new[] { "90, 252, 3", "6, 194, 112", "203, 235, 190", "198, 190, 235", "231, 235, 190", "235, 208, 190" };

            int colorIndex = -1;
            int numberOfActions = 0;
            foreach (var section in sections)
            {
                DrawSectionRectangle(section, rectangleColors, ref colorIndex);
                ActionRectangle lastAction = new ActionRectangle("null", "null");

                foreach (var action in section.Value)
                {
                    DrawActionRectangle(action, rectangleColors, colorIndex, out ActionRectangle actionRectangle);
                    UpdateActionCoordinates(actionRectangle.GetDimensions().width);
                    numberOfActions++;
                    lastAction = actionRectangle;
                    foreach (string user in action.users)
                    {
                    }
                }

                UpdateSectionCoordinates(lastAction.GetDimensions().width);
            }

            Arrow drawArrow = new Arrow((numberOfActions * 150) + (numberOfActions * 20));
            drawArrow.UpdateCoordinates(arrowCoords);
            UpdateBackground(drawArrow.GetDimensions());
        }

        private void DrawActionRectangle((string actionName, int score, List<string> users) action, string[] rectangleColors, int colorIndex, out ActionRectangle actionRectangle)
        {
            actionRectangle = new ActionRectangle(action.actionName, rectangleColors[colorIndex]);
            actionRectangle.UpdateCoordinates(actionCoords);
            actionRectangle.Draw();
        }

        private void DrawSectionRectangle(KeyValuePair<string, List<(string actionName, int score, List<string> users)>> section, string[] rectangleColors, ref int colorIndex)
        {
            var sectionRectangle = new SectionRectangle(section.Key, rectangleColors[colorIndex++]);
            sectionRectangle.UpdateCoordinates(sectionCoords);
            sectionRectangle.Draw();
        }

        private void DrawDot(string color, (int x, int y) coordinates)
        {
            var dot = new UserDot(color);
            dot.UpdateCoordinates(coordinates);
            dot.Draw();
        }

        private void UpdateSectionCoordinates(int width)
        {
            int old = sectionCoords.horizontalSection;
            sectionCoords.horizontalSection = old + width + 20;
        }

        private void UpdateActionCoordinates(int width)
        {
            int old = actionCoords.horizontalAction;
            actionCoords.horizontalAction = old + width + 20;
        }

        private void UpdateBackground((int width, int height) dimensions)
        {
            background = dimensions;
        }
    }
}