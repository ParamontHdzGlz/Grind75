using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Grind75
{
    internal class ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            string cleanString = Regex.Replace(s.ToLower(), "[^a-z0-9]", string.Empty);

            for (int i= 0; i < cleanString.Length/2; i++)
            {
                if (cleanString[i] != cleanString[cleanString.Length - i - 1]) return false;
            }

            return true;
        }
    }
}
