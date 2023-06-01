using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Extra
{
    internal class MyStack<T> where T : class
    {
        private class StackNode<T>
        {
            public T value;
            public StackNode<T> next;
            public StackNode(T val)
            {
                value = val;
                next = null;
            }
        }

        private StackNode<T> _top;
        private int _size;
        public int Size { get => _size; }

        public MyStack()
        {
            _top = null;
            _size = 0;
        }

        public void Push(T val)
        {
            if (_size == 0)
            {
                _top = new StackNode<T>(val);
            }
            else
            {
                var dummy = _top;
                _top = new StackNode<T>(val);
                _top.next = dummy;
            }

            _size++;
        }

        public T Pop()
        {
            if (_size == 0) 
                return null;

            var poppedNode = _top;
            _top = _top.next;
            _size--;

            return poppedNode.value;
        }

        public T Peek()
        {
            return _top?.value;
        }
    }
}
