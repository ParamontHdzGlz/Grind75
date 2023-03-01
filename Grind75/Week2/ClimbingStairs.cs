using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    class ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            // hint: this equals fibonacci
            var memo = new int[n + 1];
            memo[0] = 1;
            memo[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[n];
        }

    }
}
