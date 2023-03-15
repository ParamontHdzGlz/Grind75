using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    internal class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var answer = new int[nums.Length];
            var leftMulti = new int[nums.Length];
            var rightMulti = new int[nums.Length];

            leftMulti[0] = nums[0];
            rightMulti[nums.Length - 1] = nums[nums.Length - 1];

            for (int i = 1; i < nums.Length; i++)
            {
                leftMulti[i] = leftMulti[i - 1] * nums[i];
                rightMulti[nums.Length - i - 1] = nums[nums.Length - i - 1] * rightMulti[nums.Length - i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var left = i > 0 ? leftMulti[i - 1] : 1;
                var right = i < nums.Length - 1 ? rightMulti[i + 1] : 1;

                answer[i] = left * right;
            }

            return answer;
        }
    }
}
