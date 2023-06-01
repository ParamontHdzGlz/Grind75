using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Extra
{
    internal class MyQueue<T> where T : class
    {
        private class QueueNode<T>
        {
            public T val;
            public QueueNode<T> next;

            public QueueNode(T val)
            {
                this.val = val;
            }
        }

        private QueueNode<T> _front;
        private QueueNode<T> _back;
        private int _size;

        public int Size { get => _size; }

        public MyQueue()
        {
            _front = null;
            _back = null;
            _size = 0;
        }

        public void Enqueue (T val)
        {
            var enqueuedNode = new QueueNode<T>(val);
            if (_size == 0)
            {
                _front = enqueuedNode;
                _back = enqueuedNode;
            }
            else
            {
                _back.next = enqueuedNode;
                _back = enqueuedNode;
            }

            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0) return null;

            var dequeuedNode = _front;
            _front = _front.next;
            _size--;

            return dequeuedNode.val;
        }
    }
}
