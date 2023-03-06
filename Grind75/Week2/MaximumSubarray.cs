using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    internal class MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            int currentSum = nums[0];
            int maxSum = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(currentSum + nums[i], nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }
    }
}
