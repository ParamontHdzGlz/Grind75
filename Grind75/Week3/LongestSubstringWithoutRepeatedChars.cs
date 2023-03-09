using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class LongestSubstringWithoutRepeatedChars
    {
        public int LengthOfLongestSubstring(string s)
        {
            var currSubstring = new StringBuilder();
            int maxLength = 0;

            foreach (char c in s)
            {
                var foundIndex = currSubstring.ToString().IndexOf(c);
                if (foundIndex != -1)
                    currSubstring.Remove(0, foundIndex + 1);

                currSubstring.Append(c);
                maxLength = Math.Max(maxLength, currSubstring.Length);
            }

            return maxLength;
        }
    }
}
