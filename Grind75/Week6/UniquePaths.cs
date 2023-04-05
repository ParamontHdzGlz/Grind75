using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
   public class UniquePathsClass
    {
        public int UniquePaths(int m, int n)
        {
            var memo = new Dictionary<(int, int), int>(m * n);


            int Recurse(int m, int n)
            {
                if (m == 0 || n == 0)
                    return 0;
                else if (m == 1 || n == 1)
                    return 1;
                else if (memo.ContainsKey((m, n)))
                    return memo[(m, n)];

                memo[(m, n)] = Recurse(m - 1, n) + Recurse(m , n - 1);
                return memo[(m, n)];
            }

            return Recurse(m, n);
        }
    }
}
