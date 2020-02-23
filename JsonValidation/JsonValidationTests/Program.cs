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

            return CheckForBorders(json) && CheckForInvalidCharacters(json);
        }

        private static bool CheckForUnicodeLetter(char toCheck)
        {
            return (toCheck >= 'a' && toCheck <= 'z')
                || (toCheck >= 'A' && toCheck <= 'Z');
        }

        private static bool CheckForUnicodeDigit(char toCheck)
        {
            return toCheck >= '0' && toCheck <= '9';
        }

        private static bool CheckForUnicode(string json, ref int index)
            {
            if (index + 5 > json.Length)
            {
                return false;
            }

            if (json[index + 1] != 'u')
            {
                return false;
            }

            for (int i = index + 2; i <= index + 5; i++)
            {
                if (!(CheckForUnicodeDigit(json[i]) || CheckForUnicodeLetter(json[i])))
                {
                    return false;
                }
            }

            index += 5;
            return true;
            }

        private static bool CheckForInvalidCharacters(string json)
        {
            for (int i = 1; i < json.Length - 1; i++)
            {
                if (char.IsControl(json[i]))
                {
                    return false;
                }

                if (json[i] == '\\' && !(CheckForUnicode(json, ref i) || CheckForException(json, ref i)))
                {
                    return false;
                }

                int previous = i - 1;
                if (json[i] == '"' && !CheckForException(json, ref previous))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckForException(string json, ref int index)
        {
            string[] exceptions = new[] { "\\n", "\\b", "\\f", "\\r", "\\t", "\\/" };
            string toVerify = json.Substring(index, 2);

            if (toVerify == "\\\\" || toVerify == "\\\"")
            {
                index++;
                return true;
            }

            foreach (string ex in exceptions)
            {
                if (ex == toVerify)
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