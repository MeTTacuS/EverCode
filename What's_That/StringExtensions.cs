using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace What_s_That
{
    public static class StringExtensions
    {
        public static bool ContainsOnlyNumbers(this string str)
        {
            string pattern = "[^0-9]";
            return Regex.IsMatch(str, pattern);
        }

        public static bool ContainsOnlyLetters(this string str)
        {
            string pattern = "[^a-zA-Z]";
            return Regex.IsMatch(str, pattern);
        }
    }
}
