using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class KClosestPointsToOrigin
    {

        // in one LINQ sentence...
        public int[][] KClosest(int[][] points, int k)
        {
            return points.OrderBy(p => 
            Math.Sqrt(Math.Pow(p[0], 2) + Math.Pow(p[1], 2))
                ).Take(k).ToArray();
        }
    }
}
