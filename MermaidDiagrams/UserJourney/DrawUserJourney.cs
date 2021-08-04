using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserJourney
{
    public class DrawUserJourney
    {
        readonly Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        readonly List<UserDotId> listOfUsers;
        readonly string title;
        (int horizontalUserId, int verticalUserId) userIdCoords;
        (int horizontalFace, int verticalFace) faceCoords;
        (int horizontalTitle, int verticalTitle) titleCoords;
        (int horizontalSection, int verticalSection) sectionCoords;
        (int horizontalAction, int verticalAction) actionCoords;
        (int horizontalArrow, int verticalArrow) arrowCoords;
        (int width, int height) background = (0, 0);

        public DrawUserJourney(Dictionary<string, List<(string actionName, int score, List<string> users)>> sections, string title)
        {
            this.title = title;
            listOfUsers = null;
            this.sections = sections;
            titleCoords = (150, 80);
            userIdCoords = (20, sectionCoords.verticalSection + 4);
            sectionCoords = (titleCoords.horizontalTitle, titleCoords.verticalTitle + 20);
            actionCoords = (titleCoords.horizontalTitle, sectionCoords.verticalSection + 10);
            faceCoords = (actionCoords.horizontalAction, 0);
            arrowCoords = (titleCoords.horizontalTitle, actionCoords.verticalAction + 20);
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
            string drawTitle = "<text x=\"" + titleCoords.horizontalTitle + "\" y=\"" + titleCoords.verticalTitle +
                               "\" font-size=35px>\"" + title + "<text>";
            background += drawTitle;
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
                    DrawFace(action.score, ref background, ref faceCoords, actionRectangle.GetCoordinates().x);
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
                    DrawDot(newUser.GetColor(), coordinates, ref background);
                    colorIndex++;
                }

                CheckIndex(ref colorIndex, userDotColors);
            }
        }

        private void DrawFace(int score, ref string background, ref (int x, int y) coordinates, int actionCoordX)
        {
            IUserJourney face = new SmileyFace();
            switch (score)
            {
                case 5:
                    {
                        face = new SmileyFace();
                        coordinates = (actionCoordX, 40);
                        break;
                    }

                case 3:
                    {
                        face = new NeutralFace();
                        coordinates = (actionCoordX, 80);
                        break;
                    }

                case 1:
                    {
                        face = new SadFace();
                        coordinates = (actionCoordX, 120);
                        break;
                    }

                default:
                    {
                        Console.Write("Invalid option!");
                        break;
                    }
            }

            face.UpdateCoordinates(coordinates);
            background += face.Draw();
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
