using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    internal class CombinationSumClass
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            void combinationsBFS (int index, IList<int> currList, int total = 0)
            {
                if (total == target)
                {
                    result.Add(new List<int>(currList));
                    return;
                }
                else if (total > target ||
                    index >= candidates.Length)
                {
                    return;
                }

                // decision tree: pass the list adding the current index, and limiting options to the next candidates
                currList.Add(candidates[index]);
                combinationsBFS(index, currList, total + candidates[index]);
                
                // and pass without it
                currList.RemoveAt(currList.Count - 1);
                combinationsBFS(index + 1, currList, total);

            }

            combinationsBFS(0, new List<int>());

            return result;
        }
    }
}
