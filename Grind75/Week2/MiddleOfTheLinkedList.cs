using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    internal class MiddleOfTheLinkedList
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            return BrowseList(slow, fast);
        }

        private ListNode BrowseList(ListNode slow, ListNode fast)
        {
            if (fast == null || fast.next == null)
                return slow;

            return BrowseList(slow.next, fast.next.next);
        }


        // Definition for singly-linked list.
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
