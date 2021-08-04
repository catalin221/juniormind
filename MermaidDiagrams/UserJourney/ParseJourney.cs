using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserJourney
{
    public class ParseJourney
    {
        private Dictionary<string, List<(string actionName, int score, List<string> users)>> sections;
        private string title;

        public void ParseSource(string path)
        {
            StreamReader reader = File.OpenText(path);
            string line = reader.ReadLine();
            if (!ValidateJourney(line))
            {
                throw new System.InvalidOperationException("The file format is not valid!");
            }

            KeyValuePair<string, List<(string actionName, int score, List<string> users)>> lastEntry =
                new KeyValuePair<string, List<(string actionName, int score, List<string> users)>>();
            ParseLine(line, ref lastEntry);
        }

        private void ParseLine(string line, ref KeyValuePair<string, List<(string actionName, int score, List<string> users)>> entry)
        {
            string[] splitLine;
            TrimAndSplit(line, out splitLine);

            if (CheckIfTitle(splitLine[0]))
            {
                title = ParseSectionOrTitle(line);
            }
            else if (CheckIfSection(splitLine[0]))
            {
                entry = new KeyValuePair<string, List<(string actionName, int score, List<string> users)>>(ParseSectionOrTitle(line), null);
                sections.Add(entry.Key, entry.Value);
            }
        }

        private string ParseSectionOrTitle(string line)
        {
            string value;
            string[] result;
            TrimAndSplit(line, out result);
            if (!CheckIfSection(result[0]) || !CheckIfTitle(result[0]))
            {
                throw new System.InvalidOperationException("The file format is not valid!");
            }

            if (!ValidateSectionOrTitle(result, out value))
            {
                throw new System.InvalidOperationException("The file format is not valid!");
            }

            return value;
        }

        private bool ValidateJourney(string line)
        {
            string[] splitLine;
            TrimAndSplit(line, out splitLine);
            return CheckIfJourney(splitLine[0]) && splitLine.Length == 1;
        }

        private bool ValidateSectionOrTitle(string[] result, out string value)
        {
            value = "";
            if (result.Length == 1)
            {
                return false;
            }

            ProcessLine(result, ref value);
            return true;
        }

        private void ProcessLine(string[] result, ref string value)
        {
            for (int i = 1; i < result.Length; i++)
            {
                value += result[i] + ' ';
            }
        }

        private void TrimAndSplit(string line, out string[] trimmed)
        {
            trimmed = line.Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
        }

        private bool CheckIfSection(string toCheck)
        {
            return toCheck.ToLower() == "section";
        }

        private bool CheckIfAction(string toCheck)
        {
            return toCheck.ToLower() == "action";
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
