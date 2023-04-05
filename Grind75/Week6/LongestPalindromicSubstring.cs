using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
    public class LongestPalindromicSubstring
    {
        ///////////////////////////////////
        // more optimized solution, based on first try, but code is more compact
        ///////////////////////////////////
        public string LongestPalindrome(string s)
        {
            int start = 0, maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i); // odd length palindrome
                int len2 = ExpandAroundCenter(s, i, i + 1); // even length palindrome
                int len = Math.Max(len1, len2);

                if (len > maxLen)
                {
                    maxLen = len;
                    start = i - (maxLen - 1) / 2;
                }
            }

            return s.Substring(start, maxLen);
        }

        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }


        ///////////////////////////////////
        // First Try: works and is efficient but really verbose
        ///////////////////////////////////
        public string LongestPalindrome1(string s)
        {
            (int max, int left, int right) max = (1, 0, 0);

            for (int i = 0; i < s.Length; i++)
            {
                var found = FindNextMinimalPlindrome(s, i,
                    out (int left, int right) two,
                    out (int left, int right) three);
                if (found)
                {
                    if (two.left != -1)
                    {
                        var currval = ExplorePalindrome(s, two.left, two.right);
                        if (max.max < currval.max)
                            max = currval;
                    }

                    if (three.left != -1)
                    {
                        var currval = ExplorePalindrome(s, three.left, three.right);
                        if (max.max < currval.max)
                            max = currval;
                    }
                }
            }    

            return s.Substring(max.left, max.max);
        }

        private bool FindNextMinimalPlindrome(string s, int currIdx, 
            out (int left, int right) two,
            out (int left, int right) three)
        {
            bool ret = false;
            two = three = (-1, -1);

            if (currIdx + 1 < s.Length && s[currIdx] == s[currIdx + 1]) // 2 letter palindrome
            {
                ret = true;
                two = (currIdx, currIdx + 1);
            }

            if (currIdx + 2 < s.Length && s[currIdx] == s[currIdx + 2]) // 3 letter palindrome
            {
                ret = true;
                three = (currIdx, currIdx + 2);
            }


            return ret;
        }

        private (int max, int left, int right) ExplorePalindrome(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length &&
                s[left] == s[right])
            {
                left--;
                right++;
            }

            return (right - left - 1, left + 1, right - 1);
        }
    }
}
