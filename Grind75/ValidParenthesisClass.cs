using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    class ValidParenthesisClass
    {
        private readonly Dictionary<char, char> _parenthesisDict = new Dictionary<char, char> {
            { ')' , '('},
            { '}' , '{'},
            { ']' , '['}
        };

        public bool IsValid(string s)
        {
            var openParenthesis = new Stack<char>();

            foreach (char currentChar in s)
            {
                if (!_parenthesisDict.ContainsKey(currentChar))
                {
                    openParenthesis.Push(currentChar);
                }
                else
                {
                    if (_parenthesisDict[currentChar] == openParenthesis.FirstOrDefault())
                        openParenthesis.Pop();
                    else
                        return false;
                }
            }

            if (openParenthesis.Count == 0) return true;

            return false;
        }
    }
}
