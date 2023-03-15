using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    public class MinStack
    {
        private Stack<int> _stack;
        private Stack<int> _minstack;

        public MinStack()
        {
            _stack = new Stack<int>();
            _minstack = new Stack<int>();
        }

        public void Push(int val)
        {
            _stack.Push(val);
            if (_minstack.Count > 0)
                _minstack.Push(Math.Min(_minstack.Peek(), val));
            else
                _minstack.Push(val);
        }

        public void Pop()
        {
            _stack.Pop();
            _minstack.Pop();
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _minstack.Peek();
        }
    }
}
