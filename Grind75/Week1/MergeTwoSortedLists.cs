﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            ListNode result;

            if (list1 == null || list2 == null)
            {
                return list1 ?? list2;
            }

            if (list1.val < list2.val)
            {
                result = list1;
                list1 = list1.next;
            }
            else
            {
                result = list2;
                list2 = list2.next;
            }

            result.next = MergeTwoLists(list1, list2);

            return result;

        }


        //Definition for singly-linked list.
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
