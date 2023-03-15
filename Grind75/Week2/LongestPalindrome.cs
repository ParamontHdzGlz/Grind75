using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    class LongestPalindromeClass
    {
        public int LongestPalindrome(string s)
        {
            var lettersDict = s.GroupBy(s => s)
                .ToDictionary(g => g.Key, g => g.Count());


            bool oddFound = false;
            int longestPalindrome = 0;

            foreach (var val in lettersDict.Values)
            { 
                if (val % 2 == 0)
                {
                    longestPalindrome += val;
                }
                else
                {
                    if (!oddFound)
                    {
                        longestPalindrome += 1;
                        oddFound = true;
                    } 

                    longestPalindrome += val - 1;
                }
            }

            return longestPalindrome;
        }
    }
}
