using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserJourney
{
    public class ParseJourney
    {
        private readonly Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        private readonly List<string> userID;
        private string title;

        public ParseJourney()
        {
            this.sections = new Dictionary<string, List<(string actionName, int score, List<string> users)>>();
            this.userID = new List<string>();
            this.title = "";
        }

        public void ParseSource(string path)
        {
            StreamReader reader = File.OpenText(path);
            int lineCount = 0;
            KeyValuePair<string, List<(string actionName, int score, List<string> users)>> lastEntry =
                new KeyValuePair<string, List<(string actionName, int score, List<string> users)>>();

            string line = reader.ReadLine();
            while (line != null)
            {
                lineCount++;
                if (lineCount == 1)
                {
                    ValidateFirstLine(line);
                }
                else
                {
                    ParseLine(line, ref lastEntry);
                }

                line = reader.ReadLine();
            }

            reader.Close();
        }

        public Dictionary<string, List<(string actionName, int score, List<string> users)>> GetDictionary()
        {
            return this.sections;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public List<string> GetUsers()
        {
            this.userID.Sort();
            return userID;
        }

        private void ParseLine(string line, ref KeyValuePair<string, List<(string actionName, int score, List<string> users)>> entry)
        {
            string firstWord = GetFirstWord(line);
            if (CheckIfTitle(firstWord))
            {
                title = ParseSectionOrTitle(line);
            }
            else if (CheckIfSection(firstWord))
            {
                entry = new KeyValuePair<string, List<(string actionName, int score, List<string> users)>>(ParseSectionOrTitle(line), new List<(string actionName, int score, List<string> users)>());
                sections.Add(entry.Key, entry.Value);
            }
            else if (ValidateAction(line, out (string actionName, int score, List<string> users) values))
            {
                sections[entry.Key].Add(values);
            }
            else
            {
                throw new System.InvalidOperationException("The file format is not valid!");
            }
        }

        private string GetFirstWord(string line)
        {
            string trimmed = line.Trim();
            return trimmed.Substring(0, trimmed.TakeWhile(x => x != ' ').Count());
        }

        private string ParseSectionOrTitle(string line)
        {
            string value;
            string[] result;
            TrimAndSplit(line, out result);

            if (!ValidateSectionOrTitle(result, out value))
            {
                throw new System.InvalidOperationException("The file format is not valid!");
            }

            return value;
        }

        private void TrimValues(string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }
        }

        private void TrimAndSplit(string line, out string[] trimmed)
        {
            trimmed = line.Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
        }

        private void TrimAndSplitAction(string line, out string[] trimmed)
        {
            char[] delimiters = { ':', ',' };
            var temp = line.Trim().Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
            TrimValues(temp);
            trimmed = temp;
        }

        private bool ValidateAction(string line, out (string actionName, int score, List<string> actors) values)
        {
            TrimAndSplitAction(line, out string[] result);
            values = default;
            if (result.Length < 3)
            {
                return false;
            }

            if (!(ValidateActionOrActors(result[0]) && ValidateScore(result[1]) && ValidateActionOrActors(result[2])))
            {
                return false;
            }

            ProcessAction(result, ref values);
            return true;
        }

        private void ProcessAction(string[] result, ref (string action, int score, List<string> actors) values)
        {
            List<string> tempActors = result.ToList().GetRange(2, result.Length - 2);
            values = (result[0], System.Convert.ToInt32(result[1]), tempActors);
            AddUserIds(tempActors);
        }

        private void AddUserIds(List<string> actors)
        {
            foreach (string actor in actors)
            {
                if (userID.Contains(actor))
                {
                    continue;
                }

                userID.Add(actor);
            }
        }

        private void ProcessSectionOrTitle(string[] result, ref string value)
        {
            for (int i = 1; i < result.Length; i++)
            {
                value += result[i] + ' ';
            }
        }

        private void ValidateFirstLine(string line)
            {
            if (ValidateJourney(line))
            {
                return;
            }

            throw new System.InvalidOperationException("The file format is not valid!");
        }

        private bool ValidateJourney(string line)
        {
            TrimAndSplit(line, out string[] splitLine);
            return CheckIfJourney(splitLine[0]) && splitLine.Length == 1;
        }

        private bool ValidateSectionOrTitle(string[] result, out string value)
        {
            value = "";
            if (result.Length == 1)
            {
                return false;
            }

            ProcessSectionOrTitle(result, ref value);
            return true;
        }

        private bool ValidateActionOrActors(string validate)
        {
            return !string.IsNullOrEmpty(validate);
        }

        private bool ValidateScore(string score)
        {
            return score == "1" || score == "3" || score == "5";
        }

        private bool CheckIfSection(string toCheck)
        {
            return toCheck.ToLower() == "section";
        }

        private bool CheckIfJourney(string toCheck)
        {
            return toCheck.ToLower() == "journey";
        }

        private bool CheckIfTitle(string toCheck)
        {
            return toCheck.ToLower() == "title";
        }
    }
}
