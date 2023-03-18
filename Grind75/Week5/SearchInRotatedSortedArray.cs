using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    internal class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int middle;

            while (left != right)
            {
                middle = (left + right) / 2;
                if (nums[middle] == target)
                    return middle;

                if (nums[left] <= nums[middle])
                {
                    if (nums[left] <= target && target < nums[middle])
                        right = middle - 1;
                    else
                        left = middle + 1;
                }
                else
                {
                    if (nums[middle] < target && target <= nums[right])
                        left = middle + 1;
                    else
                        right = middle - 1;
                }

            }

            return nums[left] == target ? left : -1;
        }
    }
}
