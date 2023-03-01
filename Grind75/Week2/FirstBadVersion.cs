using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    public class FirstBadVersionClass : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            int middle;

            while (left < right)
            {
                middle = (left + right) / 2;


                if (IsBadVersion(middle))
                    right = middle;
                else
                    left = middle+1;
            }

            return left;
        }
    }

    public class VersionControl
    {
        // just a mock of the function so that compiler dsnt complain
        public bool IsBadVersion(int n) => true;
    }
}
