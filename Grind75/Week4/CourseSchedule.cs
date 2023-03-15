using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    class CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // build the graph
            var graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var preReq in prerequisites)
            {
                graph[preReq[0]].Add(preReq[1]);
            }

            // check for cycles
            var visits = new int[numCourses];
            Array.Fill(visits, 0);
            for (int i = 0; i < numCourses; i++)
            {
                if (FindCycleinNodePath(graph, ref visits, i))
                    return false;
            }

            return true;
        }

        private bool FindCycleinNodePath(List<int>[] graph, ref int[] visits, int startingNode)
        {
            if (visits[startingNode] == -1) // node discarded, no need to contiue
                return false;
            else if (visits[startingNode] > 0) // node already visited, cycle found
                return true;
            else // first visit to node
                visits[startingNode]++;

            foreach(int childNode in graph[startingNode])
            {
                 if (FindCycleinNodePath(graph, ref visits, childNode))
                    return true;     
            }

            visits[startingNode] = -1; // discard node if no cycle found for its paths

            return false;
        }
    }
}
