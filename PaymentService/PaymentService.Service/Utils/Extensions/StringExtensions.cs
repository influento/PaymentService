using System.Text.RegularExpressions;

namespace PaymentService.Service.Utils.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks whether a given string is valid card number using Luhn algorithm
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// true if given string is valid card number
        /// false if given string is invalid card number
        /// </returns>
        public static bool IsCardNumber(this string value)
        {
            int sum = 0;
            int length = value.Length;
            for (int i = 0; i < length; i++)
            {
                int add = (value[i] - '0') * (2 - (i + length) % 2);
                add -= add > 9 ? 9 : 0;
                sum += add;
            }
            return sum % 10 == 0;
        }

        /// <summary>
        /// Checks whether a given string is valid email
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// true if given string is email
        /// false if given string is not email
        /// </returns>
        public static bool IsEmail(this string value)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(value, pattern))
            {
                return true;
            }
            return false;
        }

    }
}
