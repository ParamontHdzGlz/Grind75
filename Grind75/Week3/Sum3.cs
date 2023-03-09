using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class Sum3
    {

        // Brute Force (does not work)
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            var val_indexDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length-2; i++)
            {
                for (var j = 1; j < nums.Length-1; j++)
                {
                    for (var k = 2; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var triplet = new List<int> { nums[i], nums[j], nums[k] }.OrderBy(x => x).ToList();

                            if (!result.Contains(triplet))
                                    result.Add(triplet.OrderBy(x => x).ToList());
                        }
                    }
                }
            }

            return result;
        }
    }
}
