using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.MergeTwoSortedLists;

namespace Grind75
{
    internal class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            var checkedNodes = new HashSet<ListNode>();

            while(head != null)
            {
                if (checkedNodes.Contains(head))
                    return true;
            }

            return false;
        }
    }
}
