using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            bool inserted = false;

            if (intervals.Length == 0) return new int[][] { newInterval };

            foreach (var interval in intervals)
            {
                bool overlap = false;
                if (!inserted)
                {
                    if (newInterval[0] >= interval[0] && newInterval[0] <= interval[1])
                    {
                        newInterval[0] = interval[0];
                        overlap = true;
                    }
                    if (newInterval[1] >= interval[0] && newInterval[1] <= interval[1])
                    {
                        newInterval[1] = interval[1];
                        overlap = true;
                    }
                    else if (interval[0] >= newInterval[0] && interval[1] <= newInterval[1])
                    {
                        overlap = true;
                    }

                    if (interval[0] >= newInterval[1])
                    {
                        result.Add(newInterval);
                        inserted = true;
                    }
                }

                if (!overlap)
                    result.Add(interval);

            }

            if (!inserted)
                result.Add(newInterval);

            return result.ToArray();
        }

    }
}
