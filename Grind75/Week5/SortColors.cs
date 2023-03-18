using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    internal class SortColorsClass
    {
        public void SortColors(int[] nums)
        {
            int bucketNum = 3;
            var count = new int[bucketNum];

            foreach (var num in nums)
            {
                count[num]++;
            }

            int currBucket = 0;
            int i = 0;
            while (i < nums.Length)
            {
                while (count[currBucket] > 0)
                {
                    nums[i] = currBucket;
                    count[currBucket]--;
                }
                currBucket++;
            }
            
        }

        // Trying to solve  using pointers and swaps but failed !
        //public void SortColors(int[] nums)
        //{
        //    // pointers for last ordered number (0, 1, 2)
        //    var pointers = new int[3];
        //    Array.Fill(pointers, -1);
        //    pointers[nums[0]]++;

        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        switch (nums[i])
        //        {
        //            case 0:
        //                pointers[0]++;
        //                pointers[1]++;
        //                pointers[2]++;
        //                Switch(ref nums, i, pointers[0]);
        //                if (pointers[1] != pointers[0])
        //                    Switch(ref nums, pointers[0], pointers[1]);
        //                break;
        //            case 1:
        //                pointers[1]++;
        //                pointers[2]++;
        //                Switch(ref nums, i, pointers[1]);
        //                break;
        //            case 2:
        //                pointers[2]++;
        //                break;
        //        }
        //    }

        //}

        //private void Switch(ref int[] array, int index1, int index2)
        //{
        //    var dummy = array[index1];
        //    array[index1] = array[index2];
        //    array[index2] = dummy;
        //}
    }
}
