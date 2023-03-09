using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class EvaluateReversePolishNotation
    {

        readonly private Dictionary<string, Func<int, int, int>> _opDict = new Dictionary<string, Func<int, int, int>>
        {
            {"+", ((x,y) => y+x) },
            {"-", ((x,y) => y-x) },
            {"*", ((x,y) => y*x) },
            {"/", ((x,y) => y/x) }
        };

        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<string>(tokens);
            return (int)EvalRPNRecurse(ref stack);

        }

        public int EvalRPNRecurse(ref Stack<string> stack) // passing by ref helps memory: no stack copies created when passing to method.
        {
            var token = stack.Pop();
            int res;

            if (_opDict.ContainsKey(token))
            {
                // using the Func lambda in the dict, passing x and y.
                res = _opDict[token](
                    EvalRPNRecurse(ref stack),
                    EvalRPNRecurse(ref stack)
                    );
            }
            else
            {
                res = Int16.Parse(token); // Int16 because number are etween -200 and 200.
            }

            return res;
        }
    }
}
