using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    public class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {

            if (nums.Length == 1)
                return new List<IList<int>> { new List<int> { nums[0] } };

            int first = nums[0];
            int[] rest = nums.Skip(1).ToArray();

            var permutationsWithoutFirst = Permute(rest);

            var allPermutations = new List<IList<int>>();
            foreach (var perm in permutationsWithoutFirst)
            {
                for (int i = 0; i <= perm.Count; i++)
                {
                    var newPerm = new List<int>();
                    newPerm.AddRange(((List<int>)perm).GetRange(0, i));
                    newPerm.Add(first);
                    newPerm.AddRange(((List<int>)perm).GetRange(i, perm.Count - i));

                    allPermutations.Add(newPerm);
                }
            }

            return allPermutations;
        }
    }
}
