using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserJourney
{
    public class DrawUserJourney
    {
        readonly Dictionary<string, string> drewDots;
        Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        List<string> userID;
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
            drewDots = new Dictionary<string, string>();
            this.title = "";
            this.sections = default;
            drewDots = new Dictionary<string, string>();
            titleCoords = (150, 80);
            sectionCoords = (titleCoords.horizontalTitle, titleCoords.verticalTitle + 20);
            actionCoords = (titleCoords.horizontalTitle, 0);
            arrowCoords = (titleCoords.horizontalTitle, 0);
            faceCoords = (0, 0);
            userIdCoords = (20, sectionCoords.verticalSection + 4);
        }

        public void DrawJourney(string path)
        {
            var parser = new ParseJourney();
            parser.ParseSource("D:\\journey\\input.txt");
            this.title = parser.GetTitle();
            this.sections = parser.GetDictionary();
            this.userID = parser.GetUsers();
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
                "212, 251, 255", "227, 227, 227", "255, 221, 148", "159, 228, 252", "159, 252, 230", "159, 252, 170", "238, 182, 252",
                "182, 198, 252", "252, 182, 249", "245, 193, 213", "250, 220, 242", "249, 250, 220", "232, 250, 220"
            };

            string[] userDotColors = new[] { "90, 252, 3", "6, 194, 112", "203, 235, 190", "198, 190, 235", "231, 235, 190", "235, 208, 190" };
            string drawTitle = "<text x=\"" + titleCoords.horizontalTitle + "\" y=\"" + titleCoords.verticalTitle +
                               "\" font-size=\"35px\">" + title + "</text>";
            background += drawTitle;
            int colorIndexSection = -1;
            int colorIndexDots = 0;
            int numberOfActions = 0;
            int sectionHeight = 0;
            ActionRectangle lastAction = new ActionRectangle("null", "null");
            DrawAllDots(userID, ref colorIndexDots, userDotColors, ref userIdCoords, ref background);

            foreach (var section in sections)
            {
                DrawSectionRectangle(section, rectangleColors, ref colorIndexSection, ref background, out int height, out (int x, int y) coordinates);
                foreach (var action in section.Value)
                {
                    UpdateActionVertical(height, coordinates.y);
                    DrawActionRectangle(action, rectangleColors, colorIndexSection, out ActionRectangle actionRectangle, ref background);
                    UpdateActionCoordinates(actionRectangle.GetDimensions().width);
                    numberOfActions++;
                    lastAction = actionRectangle;
                    (int x, int y) actionCoordinates = actionRectangle.GetCoordinates();
                    DrawUserDots(action.users,  ref background, ref actionCoordinates);
                    UpdateFaceCoordinates(height, lastAction.GetCoordinates().x, lastAction.GetCoordinates().y, lastAction.GetDimensions().width);
                    DrawFace(action.score, ref background);
                }

                sectionHeight = height;
                UpdateBackgroundHeight(lastAction.GetDimensions().height);
                UpdateSectionCoordinates(lastAction.GetDimensions().width, lastAction.GetCoordinates().x);
            }

            UpdateArrowVertical(ref arrowCoords, sectionHeight);
            DrawArrow(numberOfActions, ref background, out int width);
            UpdateBackgroundWidth(width);
        }

        private void DrawUserDots(List<string> users, ref string background, ref (int x, int y) coordinates)
        {
            foreach (string user in users.Distinct())
            {
                const int dotRadius = 7;
                UserDot userDot = new UserDot(drewDots[user]);
                userDot.UpdateCoordinates(coordinates);
                background += userDot.Draw();
                coordinates.x += dotRadius;
            }
        }

        private void DrawAllDots(List<string> users, ref int colorIndex, string[] colors, ref (int x, int y) coordinates, ref string background)
        {
            foreach (var user in users)
            {
                const int spaceBetweeenDots = 20;
                CheckIndex(ref colorIndex, colors);
                drewDots.Add(user, colors[colorIndex++]);
                UserDotId userDot = new UserDotId(user, drewDots[user]);
                userDot.UpdateCoordinates(coordinates);
                background += userDot.Draw();
                coordinates.y += spaceBetweeenDots;
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
            out int height,
            out (int x, int y) coordinates)
        {
            CheckIndex(ref colorIndex, rectangleColors);
            var sectionRectangle = new SectionRectangle(section.Key, rectangleColors[++colorIndex]);
            sectionRectangle.UpdateCoordinates(sectionCoords);
            coordinates = sectionRectangle.GetCoordinates();
            background += sectionRectangle.Draw();
            height = sectionRectangle.GetDimensions().height;
        }

        private void UpdateSectionCoordinates(int width, int lastActionX)
        {
            sectionCoords.horizontalSection = lastActionX + width + 20;
        }

        private void DrawArrow(int numberOfActions, ref string background, out int width)
        {
            Arrow drawArrow = new Arrow((numberOfActions * 150) + (numberOfActions * 20));
            drawArrow.UpdateCoordinates(arrowCoords);
            background += drawArrow.Draw();
            width = drawArrow.GetDimensions().width;
        }

        private void UpdateFaceCoordinates(int height, int actionX, int actionY, int width)
        {
            const int verticalSpacing = 60;
            this.faceCoords.horizontalFace = actionX + (width / 2);
            this.faceCoords.verticalFace = actionY + height + verticalSpacing;
        }

        private void UpdateActionVertical(int height, int sectionY)
        {
            this.actionCoords.verticalAction = sectionY + height + 10;
        }

        private void UpdateArrowVertical(ref (int horizontal, int vertical) coords, int height)
        {
            coords.vertical = actionCoords.verticalAction + height + 20;
        }

        private void UpdateBackgroundWidth(int width)
        {
            const int arrowHeadDimension = 30;
            const int marginSpace = 150;
            background.width = width + marginSpace + arrowHeadDimension;
        }

        private void UpdateBackgroundHeight(int height)
        {
            background.height = 2 * height;
        }
    }
}
