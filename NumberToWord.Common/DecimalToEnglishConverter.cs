using System;

namespace NumberToWord.Common
{
    public class DecimalToEnglishConverter : INumberToWordService<decimal>
    {
        private readonly string[] _onesMap = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private readonly string[] _teensMap = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] _tensMap = { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private readonly string[] _thousands = { "", " Thousand", " Million", " Billion" };


        /// <summary>
        /// Converts the specified number to its English currency representation.
        /// </summary>
        /// <param name="numberToConvert">The number to convert.</param>
        /// <returns></returns>
        /// <exception cref="System.FormatException">Money out of the range (1 -2 billion)</exception>
        public string Convert(decimal numberToConvert)
        {
            string result = "";
            int dollars = GetDollars(numberToConvert);
            int cents = GetCents(numberToConvert);

            if (numberToConvert <= 0 || numberToConvert > 2000000000)
            {
                throw new FormatException("Money out of the range (1 -2 billion)");
            }

            if (cents == 0)
            {
                result = string.Format("{0} Dollars", ConvertIntToWord(dollars, "", 0));
            }
            else if (dollars == 0)
            {
                result = string.Format("{0} Cents", ConvertIntToWord(cents, "", 0));
            }
            else
            {
                result = string.Format("{0} Dollars and {1} Cents",
                    ConvertIntToWord(dollars, "", 0),
                    ConvertIntToWord(cents, "", 0));
            }

            return result;
        }


        private int GetDollars(decimal numberToConvert)
        {
            return (int)decimal.Truncate(numberToConvert);
        }

        private int GetCents(decimal numberToConvert)
        {
            var decimalValue = Math.Round(numberToConvert - GetDollars(numberToConvert), 2, MidpointRounding.AwayFromZero);
            var cents = decimalValue*100;
            return (int)cents;
        }

        //Actual logic to convert the decimal to word
        private string ConvertIntToWord(int n, string stringLeft, int thousand)
        {
            if (n == 0)
            {
                return stringLeft;
            }
            string stringNumber = stringLeft;
            if (stringNumber.Length > 0)
            {
                stringNumber += " ";
            }

            if (n < 10)
            {
                stringNumber += _onesMap[n];
            }
            else if (n < 20)
            {
                stringNumber += _teensMap[n - 10];
            }
            else if (n < 100)
            {
                stringNumber += ConvertIntToWord(n % 10, _tensMap[n / 10 - 2], 0);
            }
            else if (n < 1000)
            {
                string hundred = n % 100 > 0 ? " Hundred and" : " Hundred";
                stringNumber += ConvertIntToWord(n % 100, (_onesMap[n / 100] + hundred), 0);
            }
            else
            {
                stringNumber += ConvertIntToWord(n % 1000, ConvertIntToWord(n / 1000, "", thousand + 1), 0);
                if (n % 1000 == 0) return stringNumber;
            }

            return stringNumber + _thousands[thousand];
        }
    }
}
