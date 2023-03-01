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
            var lettersDict = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
                lettersDict[c] = 0;
            for (char c = 'A'; c <= 'Z'; c++)
                lettersDict[c] = 0;

            foreach (char c in s)
                lettersDict[c]++;


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
