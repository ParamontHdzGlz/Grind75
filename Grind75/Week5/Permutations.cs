using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    internal class Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {

            if (nums.Length == 0)
                return (IList<IList<int>>) new List<List<int>> { new List<int>() };

            int first = nums[0];
            int[] rest = nums.Skip(0).ToArray();

            var permutationsWithoutFirst = Permute(rest);

            var allPermutations = new List<List<int>>();

            foreach (var perm in permutationsWithoutFirst)
            {
                for (int i = 0; i < perm.Count; i++)
                {
                    var newPerm = new List<int>();
                    newPerm.AddRange(((List<int>)perm).GetRange(0, i));
                    newPerm.Add(first);
                    newPerm.AddRange(((List<int>)perm).GetRange(i, perm.Count - i));

                    allPermutations.Add(newPerm);
                }
            }

            return (IList<IList<int>>)allPermutations;
        }
    }
}
