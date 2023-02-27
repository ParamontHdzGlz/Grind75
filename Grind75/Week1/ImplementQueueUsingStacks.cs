using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    internal class ImplementQueueUsingStacks
    {
        private Stack<int> _mainStack;
        private Stack<int> _tempStack;

        public ImplementQueueUsingStacks()
        {
            _mainStack = new Stack<int>();
            _tempStack = new Stack<int>();
        }

        public void Push(int x)
        {
            _mainStack.Push(x);
            _tempStack = (Stack<int>)_mainStack.Reverse();
        }

        public int Pop()
        {
            var retVal = _tempStack.Pop();
            _mainStack = (Stack<int>)_tempStack.Reverse();
            return retVal;
        }

        public int Peek()
        {
            return _tempStack.Peek();
        }

        public bool Empty()
        {
            return !_mainStack.Any();
        }
    }
}
