using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    internal class MergeIntervals
    {

        public int[][] Merge(int[][] intervals)
        {
            // order input by start
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            var res = new List<int[]>();

            int index = 0;
            var curr = intervals[0];

            while (index < intervals.Length)
            {
                var next = intervals.ElementAtOrDefault(index + 1);

                if (curr[1] >= next?[0])
                {
                    curr[1] = Math.Max(curr[1], next[1]);
                    index++;
                }
                else
                {
                    res.Add(curr);
                    index++;
                    curr = next;
                }
            }

            return res.ToArray();
        }
    }
}
