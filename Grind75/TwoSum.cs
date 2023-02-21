using System;

namespace Grind75
{
    public class TwoSumClass
    {
        public int[] TwoSum(int[] nums, int target)
        {

            var result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                result[0] = i;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[1] = j;
                        return result;
                    }
                }
            }

            return new int[2];
        }

    }
}
