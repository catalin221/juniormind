using System;

namespace JsonNumberValidation
{
    public class Program
    {
        public static bool ValidateJsonNumber(string number)
        {
            if (number == null)
            {
                throw new ArgumentNullException(number);
            }

            if (CheckForBadFormats(number))
            {
                return false;
            }

            return CheckForIntegerNumber(number) || CheckForNegativeIntegerNumber(number) || CheckForRationalNumber(number);
        }

        private static bool CheckForIntegerNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!(number[i] >= '0' && number[i] <= '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckForNegativeIntegerNumber(string number)
            {
            if (!CheckForNegativeNumber(number))
            {
                return false;
            }

            for (int i = 1; i < number.Length; i++)
            {
                if (!(number[i] >= '0' && number[i] <= '9'))
                {
                    return false;
                }
            }

            return true;
            }

        private static bool CheckForBadFormats(string number)
        {
            if (CheckForWrongExponentialFormat(number) || CheckForWrongRationalFormat(number) || (CheckForZeroPrefixedNumber(number) && !CheckForSubunitaryNumber(number)))
            {
                return true;
            }

            if (CheckForZeroPrefixedNumber(number) && CheckForWrongRationalFormat(number))
            {
                return true;
            }

            return false;
        }

        private static bool CheckForWrongExponentialFormat(string number)
        {
            return number[number.Length - 1] == 'e' || number[number.Length - 1] == 'E';
        }

        private static bool CheckForZeroPrefixedNumber(string number)
        {
            return number[0] == '0';
        }

        private static bool CheckForWrongRationalFormat(string number)
        {
            return number[0] == '.' || number[number.Length - 1] == '.';
        }

        private static bool CheckForNegativeNumber(string number)
        {
            return number[0] == '-';
        }

        private static bool CheckForSubunitaryNumber(string number)
        {
            if (number[0] != '0' || number[1] != '.')
            {
                return false;
            }

            return CheckForIntegerNumber(number.Substring(2));
        }

        private static bool CheckForRationalNumber(string number)
        {
            int splitPoint = 0;
            string firstPart = "";
            string secondPart = "";
            if (number.IndexOf('.') != -1)
            {
                splitPoint = number.IndexOf('.');
            }

            if (CheckForNegativeNumber(number))
            {
                firstPart = number.Substring(1, splitPoint - 1);
                secondPart = number.Substring(splitPoint + 1, number.Length - (splitPoint + 1));
            }
            else
            {
                firstPart = number.Substring(0, splitPoint);
                secondPart = number.Substring(splitPoint + 1, number.Length - (splitPoint + 1));
            }

            return CheckForIntegerNumber(firstPart) && CheckForIntegerNumber(secondPart);
        }
    }
}
