using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserJourney
{
    public class DrawUserJourney
    {
        readonly List<UserDotId> listOfUsers;
        Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        string title;
        (int horizontalUserId, int verticalUserId) userIdCoords;
        (int horizontalFace, int verticalFace) faceCoords;
        (int horizontalTitle, int verticalTitle) titleCoords;
        (int horizontalSection, int verticalSection) sectionCoords;
        (int horizontalAction, int verticalAction) actionCoords;
        (int horizontalArrow, int verticalArrow) arrowCoords;
        (int width, int height) background = (0, 0);

        public DrawUserJourney()
        {
            this.title = "";
            this.sections = default;
            listOfUsers = new List<UserDotId>();
            titleCoords = (150, 80);
            userIdCoords = (20, sectionCoords.verticalSection + 4);
            sectionCoords = (titleCoords.horizontalTitle, titleCoords.verticalTitle + 20);
            actionCoords = (titleCoords.horizontalTitle, sectionCoords.verticalSection + 10);
            faceCoords = (actionCoords.horizontalAction, 0);
            arrowCoords = (titleCoords.horizontalTitle, actionCoords.verticalAction + 20);
        }

        public void DrawJourney(string path)
        {
            var parser = new ParseJourney();
            parser.ParseSource("D:\\journey\\input.txt");
            this.title = parser.GetTitle();
            this.sections = parser.GetDictionary();
            string tempBackground = "";
            DrawContent(ref tempBackground);
            string svgBackground = "<svg width=\"" + background.width + "\" height=\"" + background.height + "\" xmlns=\"http://www.w3.org/2000/svg\">";
            string file = svgBackground + tempBackground + "</svg>";
            StreamWriter write = File.CreateText(path);
            write.Write(file);
            write.Close();
        }

        private void DrawContent(ref string background)
        {
            string[] rectangleColors = new[]
            {
                "230, 104, 50", "230, 149, 50", "242, 219, 87", "230, 252, 81", "164, 250, 15", "25, 29, 255", "121, 58, 240",
                "138, 65, 217", "171, 65, 217", "199, 65, 217", "217, 65, 194", "217, 65, 113", "217, 65, 65"
            };

            string[] userDotColors = new[] { "90, 252, 3", "6, 194, 112", "203, 235, 190", "198, 190, 235", "231, 235, 190", "235, 208, 190" };
            string drawTitle = "<text x=\"" + titleCoords.horizontalTitle + "\" y=\"" + titleCoords.verticalTitle +
                               "\" font-size=\"35px\">" + title + "</text>";
            background += drawTitle;
            int colorIndex = 0;
            int numberOfActions = 0;
            foreach (var section in sections)
            {
                DrawSectionRectangle(section, rectangleColors, ref colorIndex, ref background, out int height);
                ActionRectangle lastAction = new ActionRectangle("null", "null");

                foreach (var action in section.Value)
                {
                    DrawActionRectangle(action, rectangleColors, colorIndex, out ActionRectangle actionRectangle, ref background);
                    UpdateActionCoordinates(actionRectangle.GetDimensions().width);
                    numberOfActions++;
                    lastAction = actionRectangle;
                    (int x, int y) actionCoordinates = actionRectangle.GetCoordinates();
                    DrawUserDots(action.users, userDotColors, out colorIndex, ref background, actionCoordinates);
                    UpdateFaceCoordinates(height, lastAction.GetCoordinates().x, lastAction.GetCoordinates().y, lastAction.GetDimensions().width);
                    DrawFace(action.score, ref background);
                }

                UpdateBackgroundHeight(lastAction.GetDimensions().height);
                UpdateSectionCoordinates(lastAction.GetDimensions().width);
            }

            DrawArrow(numberOfActions, ref background);
        }

        private void DrawUserDots(List<string> users, string[] userDotColors, out int colorIndex, ref string background, (int x, int y) coordinates)
        {
            colorIndex = 0;
            CheckIndex(ref colorIndex, userDotColors);
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
            }
        }

        private void DrawFace(int score, ref string background)
        {
            IUserJourney face = new SmileyFace();
            (int horizonta, int vertical) coordinates = (0, 0);
            switch (score)
            {
                case 5:
                    {
                        face = new SmileyFace();
                        coordinates = (faceCoords.horizontalFace, faceCoords.verticalFace + 40);
                        break;
                    }

                case 3:
                    {
                        face = new NeutralFace();
                        coordinates = (faceCoords.horizontalFace, faceCoords.verticalFace + 80);
                        break;
                    }

                case 1:
                    {
                        face = new SadFace();
                        coordinates = (faceCoords.horizontalFace, faceCoords.verticalFace + 120);
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

            index = -1;
        }

        private void DrawActionRectangle(
            (string actionName, int score, List<string> users) action,
            string[] rectangleColors,
            int colorIndex,
            out ActionRectangle actionRectangle,
            ref string background)
        {
            CheckIndex(ref colorIndex, rectangleColors);
            actionRectangle = new ActionRectangle(action.actionName, rectangleColors[colorIndex]);
            actionRectangle.UpdateCoordinates(actionCoords);
            background += actionRectangle.Draw();
        }

        private void UpdateActionCoordinates(int width)
        {
            int old = actionCoords.horizontalAction;
            actionCoords.horizontalAction = old + width + 20;
        }

        private void DrawSectionRectangle(
            KeyValuePair<string, List<(string actionName, int score, List<string> users)>> section,
            string[] rectangleColors,
            ref int colorIndex,
            ref string background,
            out int height)
        {
            CheckIndex(ref colorIndex, rectangleColors);
            var sectionRectangle = new SectionRectangle(section.Key, rectangleColors[colorIndex++]);
            sectionRectangle.UpdateCoordinates(sectionCoords);
            background += sectionRectangle.Draw();
            height = sectionRectangle.GetDimensions().height;
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

        private void UpdateFaceCoordinates(int height, int actionX, int actionY, int width)
        {
            this.faceCoords.horizontalFace = actionX + (width / 2);
            this.faceCoords.verticalFace = actionY + height;
        }

        private void UpdateBackgroundWidth(int width)
        {
            background.width = width;
        }

        private void UpdateBackgroundHeight(int height)
        {
            background.height = height;
        }
    }
}
