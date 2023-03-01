using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode reverse = null;
            ListNode temp;

            while (head != null)
            {
                temp = reverse;
                reverse = head;
                head = head.next;
                reverse.next = temp;
            }

            return reverse;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
