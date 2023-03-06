using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    internal class ContainsDuplicateClass
    {

        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> ints = new HashSet<int>(nums);

            return ints.Count() != nums.Count();
        }

        // FirstTry
        public bool ContainsDuplicateFristTry(int[] nums)
        {
            HashSet<int> ints = new HashSet<int>();

            foreach(int num in nums)
            {
                if (ints.Contains(num))
                    return false;
                else
                    ints.Add(num);
            }

            return true;
        }
    }
}
