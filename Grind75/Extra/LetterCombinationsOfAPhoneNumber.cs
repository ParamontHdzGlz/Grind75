using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Extra
{
    internal class LetterCombinationsOfAPhoneNumber
    {
        private readonly Dictionary<char, char[]> _numLetterDict = new Dictionary<char, char[]>
            {
                {'2', new char[] { 'a', 'b', 'c'} },
                {'3', new char[] { 'd', 'e', 'f'} },
                {'4', new char[] { 'g', 'h', 'i'} },
                {'5', new char[] { 'j', 'k', 'l'} },
                {'6', new char[] { 'm', 'n', 'o'} },
                {'7', new char[] { 'p', 'q', 'r', 's'} },
                {'8', new char[] { 't', 'u', 'v'} },
                {'9', new char[] { 'w', 'x', 'y', 'z'} },
            };

        public IList<string> LetterCombinations(string digits)
        {
            var res = new List<string>(digits.Length * 3); // aproximate capacity
            if (digits.Length == 0) return res;

            void combinationsDFS(int index, string curr = null)
            {
                if (index == digits.Length)
                {
                    res.Add(curr);
                    return;
                }

                foreach (char c in _numLetterDict[digits[index]])
                {
                    combinationsDFS(index + 1, curr + c);
                }
            }

            combinationsDFS(0);
            return res;
        }

    }
}
