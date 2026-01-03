// InputFormats.cs by Ben Ebadinia

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WhatsItWorth
{
    class InputFormats
    {
        // Validates that the string contains only numeric digits using a regular expression.
        public static bool UsingRegex(string stringValue)
        {
            var pattern = @"^[0-9]+$";
            var regex = new Regex(pattern);
            return regex.IsMatch(stringValue);
        }


        // Validates email format by attempting to construct a MailAddress.
        public static bool EmailValidation(string emailString)
        {
            // ^[^@\s]+@[^@\s]+\.(com|net|org|gov)$
            try
            {
                var tryMail = new System.Net.Mail.MailAddress(emailString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Checks password complexity: requires at least one uppercase, lowercase, special character, and digit.
        // Returns 0 when valid; otherwise returns a code indicating the missing requirement.
        public static int PassValidation(string passString)
        {
            //string lowercase = "qwertyuiopasdfghjklzxcvbnm";
            //string uppercase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            //string digits = "0123456789";
            //string specialChars = "!@#$%^&*()_+-=[]|{};:<>?,.";
            //string minLength = 8

            if (!passString.Any(char.IsUpper))
            {
                return 1;
            }
            else if (!passString.Any(char.IsLower))
            {
                return 2;
            }
            else if (!passString.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                return 3;
            }
            else if (!passString.Any(char.IsDigit))
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }
}
