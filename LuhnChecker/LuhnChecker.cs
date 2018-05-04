using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LuhnChecker
{
    /// <summary>
	/// This class provide static method for validation entered card number based on Luhn formula.
	/// </summary>
    public static class LuhnChecker
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
            for (var i = cardNumber.Length - 1; i >= 0; i--)
            {
                var digit = int.Parse(cardNumber[i].ToString());

                // For even numbers add the digit as is.
                if ((i % 2) == 0)
                {
                    sum += digit;
                }
                else
                {
                    // For odd digits, multiply by 2 and if that
                    // digit is greater than 5, subtract 9
                    sum += (2 * digit);
                    if (digit >= 5)
                    {
                        sum -= 9;
                    }
                }
            }

            return sum % 10 == 0;
        }

    }
}
