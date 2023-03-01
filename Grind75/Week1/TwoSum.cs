using System;
using System.Collections.Generic;

namespace Grind75
{
    public class TwoSumClass
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var val_indexDict = new Dictionary<int, int>();

            for (int i=0; i< nums.Length; i++)
            {
                var numToSerach = target - nums[i];
                if (val_indexDict.ContainsKey(numToSerach))
                    return new int[] { i, val_indexDict[numToSerach] }; 
                else
                    val_indexDict[nums[i]] =  i;
            }

            return new int[2];
        }


        // First Try
        public int[] TwoSumBrute(int[] nums, int target)
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
