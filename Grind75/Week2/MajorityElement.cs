using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    class MajorityElementClass
    {
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> elementCount = nums
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            var halfLength = nums.Length / 2;
            return elementCount.First(kvp => kvp.Value > halfLength).Key;
        }
    }
}
