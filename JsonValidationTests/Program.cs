using System;

namespace JsonValidation
{
    public class Program
    {
        public static bool ValidateJsonString(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException(json);
            }

            return CheckForInvalidCharacters(json) && CheckForBorders(json);
        }

        private static bool CheckForUnicode(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException(json);
            }

            if (json.IndexOf("\\u") == -1)
            {
                return false;
            }

            int index = json.IndexOf("\\u");
            for (int i = index + 2; i <= index + 5; i++)
            {
                if (json[i] > '9' || json[i] < '0')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckForInvalidCharacters(string json)
        {
            const string invalidCharacters = "\"\\";

            if (json.Length == 1 && invalidCharacters.IndexOf(json[0]) != -1)
            {
                return false;
            }

            for (int i = 1; i < json.Length - 1; i++)
            {
                if (char.IsControl(json[i]) && json[i] != '\n')
                {
                    return false;
                }

                if (invalidCharacters.IndexOf(json[i]) != -1 && !CheckForUnicode(json))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckForBorders(string json)
        {
            return json[0] == '"' && json[json.Length - 1] == '"';
        }
    }
}
