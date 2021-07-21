using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserJourney
{
    public class DrawUserJourney
    {
        readonly Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        readonly Dictionary<int, int> scoreHeight;
        readonly List<UserDotId> listOfUsers;
        (int horizontalUserId, int verticalUserId) userIdCoords;
        (int horizontalTitle, int verticalTitle) titleCoords;
        (int horizontalSection, int verticalSection) sectionCoords;
        (int horizontalAction, int verticalAction) actionCoords;
        (int horizontalArrow, int verticalArrow) arrowCoords;
        (int width, int height) background = (0, 0);

        public DrawUserJourney(Dictionary<string, List<(string actionName, int score, List<string> users)>> sections)
        {
            listOfUsers = null;
            this.sections = sections;
            titleCoords = (150, 80);
            userIdCoords = (20, sectionCoords.verticalSection + 4);
            sectionCoords = (titleCoords.horizontalTitle, titleCoords.verticalTitle + 20);
            actionCoords = (titleCoords.horizontalTitle, sectionCoords.verticalSection + 10);
            arrowCoords = (titleCoords.horizontalTitle, actionCoords.verticalAction + 20);
            scoreHeight = new Dictionary<int, int> { { 5, 40 }, { 3, 80 }, { 1, 120 } };
        }

        public void DrawJourney(string path)
        {
            string svgBackground = "<svg width=\"" + background.width + "\" height=\"" + background.height + "\">";
            string tempBackground = "";
            DrawContent(ref tempBackground);
            string file = svgBackground + tempBackground + "</svg>";
            StreamWriter write = File.CreateText(path);
            write.Write(file);
            write.Close();
        }

        public void DrawContent(ref string background)
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
                DrawSectionRectangle(section, rectangleColors, ref colorIndex, ref background);
                ActionRectangle lastAction = new ActionRectangle("null", "null");

                foreach (var action in section.Value)
                {
                    DrawActionRectangle(action, rectangleColors, colorIndex, out ActionRectangle actionRectangle, ref background);
                    UpdateActionCoordinates(actionRectangle.GetDimensions().width);
                    numberOfActions++;
                    lastAction = actionRectangle;
                    (int x, int y) actionCoordinates = actionRectangle.GetCoordinates();
                    DrawUserDots(action.users, userDotColors, out colorIndex, ref background, actionCoordinates);
                }

                UpdateSectionCoordinates(lastAction.GetDimensions().width);
            }

            DrawArrow(numberOfActions, ref background);
        }

        private void DrawUserDots(List<string> users, string[] userDotColors, out int colorIndex, ref string background, (int x, int y) coordinates)
        {
            colorIndex = 0;
            foreach (string user in users)
            {
                UserDotId newUser = new UserDotId(user, userDotColors[colorIndex]);
                if (listOfUsers.Any(x => x.GetId() == newUser.GetId()))
                {
                    var foundUser = new UserDot(listOfUsers.First(x => x.GetId() == user).GetColor());
                    DrawDot(foundUser.GetColor(), coordinates, ref background);
                    coordinates = (coordinates.x + 10, coordinates.y);
                }
                else
                {
                    listOfUsers.Add(newUser);
                    newUser.UpdateCoordinates(userIdCoords);
                    background += newUser.Draw();
                    userIdCoords.verticalUserId += 20;
                    colorIndex++;
                }

                CheckIndex(ref colorIndex, userDotColors);
            }
        }

        private void CheckIndex(ref int index, string[] colors)
        {
            if (index != colors.Length)
            {
                return;
            }

            index = 0;
        }

        private void DrawActionRectangle(
            (string actionName, int score, List<string> users) action,
            string[] rectangleColors,
            int colorIndex,
            out ActionRectangle actionRectangle,
            ref string background)
        {
            actionRectangle = new ActionRectangle(action.actionName, rectangleColors[colorIndex]);
            actionRectangle.UpdateCoordinates(actionCoords);
            background += actionRectangle.Draw();
        }

        private void UpdateActionCoordinates(int width)
        {
            int old = actionCoords.horizontalAction;
            actionCoords.horizontalAction = old + width + 20;
        }

        private void DrawSectionRectangle(KeyValuePair<string, List<(string actionName, int score, List<string> users)>> section, string[] rectangleColors, ref int colorIndex, ref string background)
        {
            var sectionRectangle = new SectionRectangle(section.Key, rectangleColors[colorIndex++]);
            sectionRectangle.UpdateCoordinates(sectionCoords);
            background += sectionRectangle.Draw();
        }

        private void UpdateSectionCoordinates(int width)
        {
            int old = sectionCoords.horizontalSection;
            sectionCoords.horizontalSection = old + width + 20;
        }

        private void DrawDot(string color, (int x, int y) coordinates, ref string background)
        {
            var dot = new UserDot(color);
            dot.UpdateCoordinates(coordinates);
            background += dot.Draw();
        }

        private void DrawArrow(int numberOfActions, ref string background)
        {
            Arrow drawArrow = new Arrow((numberOfActions * 150) + (numberOfActions * 20));
            drawArrow.UpdateCoordinates(arrowCoords);
            UpdateBackgroundWidth(drawArrow.GetDimensions().width);
            background += drawArrow.Draw();
        }

        private void UpdateBackgroundWidth(int width)
        {
            background.width = width;
        }
    }
}
