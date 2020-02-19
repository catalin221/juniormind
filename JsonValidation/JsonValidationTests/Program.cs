sing System;

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

            return CheckForBorders(json) && CheckForInvalidCharacters(json);
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
            if (json.Length < index + 5)
            {
                return false;
            }

            for (int i = index + 2; i <= index + 5; i++)
            {
                if ((json[i] < '0' && json[i] > '9') && (json[i] < 'A' && json[i] > 'Z'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckForInvalidCharacters(string json)
        {
            const string invalidCharacters = "\"\\";

            for (int i = 1; i < json.Length - 1; i++)
            {
                if (char.IsControl(json[i]) && !CheckForException(json[i]))
                {
                    return false;
                }

                if (!CheckForUnicode(json) && invalidCharacters.IndexOf(json[i]) != -1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckForException(char json)
        {
            switch (json)
            {
                case '\n':

                case '\\':

                case '\b':

                case '\f':

                case '\r':

                case '\t':

                case '\"':
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckForBorders(string json)
        {
            if (json.Length < 2)
            {
                return false;
            }

            return json[0] == '"' && json[json.Length - 1] == '"';
        }
    }
}
