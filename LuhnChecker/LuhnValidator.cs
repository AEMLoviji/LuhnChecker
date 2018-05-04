using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LuhnChecker
{
    /// <summary>
	/// This class provide static method for validation entered card number based on Luhn formula.
	/// </summary>
    public static class LuhnValidator
    {

        /// <summary>
        /// Validates if credit card number is valid by checking it with Luhn function
        /// </summary>
        /// <param name="cardNumber">The card number in string to be validated</param>
        /// <returns>True if pass the Luhn validation, otherwise false</returns>  
        public static bool IsValid(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", string.Empty);

            if (!Regex.IsMatch(cardNumber, @"^\d+$"))
            {
                return false;
            }

            var sum = 0;
            var isOdd = false;
            var digits = cardNumber.ToCharArray();
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var curDigit = (int)char.GetNumericValue(digits[i]);
                if (isOdd)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                        curDigit -= 9;
                }
                sum += curDigit;
                isOdd = !isOdd;
            }
            return sum % 10 == 0;
        }

    }
}
