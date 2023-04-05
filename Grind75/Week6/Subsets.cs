using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
    public class SubsetsClass
    {
        // get combinations
        public IList<IList<int>> Subsets(int[] nums)
        {
            if (nums.Length == 1)
                return new List<IList<int>> { new List<int>(), new List<int> { nums[0] } };

            int first = nums[0];
            int[] rest = nums.Skip(1).ToArray();

            var combinationsWithoutFirst = Subsets(rest);
            IList<IList<int>> combinationsWithFirst = new List<IList<int>>();
            foreach (var combination in combinationsWithoutFirst)
            {
                combinationsWithFirst.Add(new List<int>(combination));
                combinationsWithFirst[combinationsWithFirst.Count - 1].Add(first);
            }

                ((List<IList<int>>)combinationsWithoutFirst).AddRange(combinationsWithFirst);
            return combinationsWithoutFirst;
        }
    }
}
