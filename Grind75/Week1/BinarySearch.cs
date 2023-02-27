using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    internal class BinarySearch
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int middle;

            while (left <= right)
            {
                middle = left + (right - left) / 2;

                if (nums[middle] == target)
                    return middle;
                else if (nums[middle] < target)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1;
        }
    }
}
