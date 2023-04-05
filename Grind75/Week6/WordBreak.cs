using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
    internal class WordBreakClass
    {
        // using dynamic programing
        public bool WordBreak(string s, IList<string> wordDict)
        {
            // records if at given index, the string can be broken down
            var memo = new bool[s.Length + 1];
            memo[s.Length] = true;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (var j = 0; j < s.Length - i; j++)
                {
                    // if substring (at index i size j+1) is contained in words
                    var sub = s.Substring(i, j + 1);
                    if (wordDict.Contains(sub))
                        // check if the memoization has result of remaining string
                        memo[i] = memo[i + sub.Length];
                    if (memo[i])
                        break;
                }
            }

            return memo[0];
        }

        // works, but exceeds time for many cases
        public bool WordBreakFirstTry(string s, IList<string> wordDict)
        {
            bool DFS(string remaining)
            {
                if (remaining.Length == 0)
                    return true;

                var possibleWords = wordDict.Where(w => remaining.StartsWith(w));

                foreach(var word in possibleWords)
                {
                    if (DFS(remaining.Substring(word.Length)))
                        return true;
                }

                return false;
            }

            return DFS(s);
        }
    }
}
