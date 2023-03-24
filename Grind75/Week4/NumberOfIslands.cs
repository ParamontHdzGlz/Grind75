using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    internal class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            var visitedLand = new HashSet<(int, int)>(); // all positions with 1's
            int nIslands = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1' && !visitedLand.Contains((i, j)))
                    {
                        ParseIslandsBFS(grid, i, j, visitedLand);
                        nIslands++;
                    }
                }
            }

            return nIslands;
        }


        private void ParseIslandsBFS(char[][] grid, int initX, int initY, HashSet<(int, int)> visitedLand)
        {

            var landToParse = new Queue<(int, int)>(new[] { (initX, initY) });

            while (landToParse.Count > 0)
            {
                (int x, int y) = landToParse.Dequeue();
                visitedLand.Add((x, y));

                // add valid neighbours
                if (ValidCell(grid, x - 1, y, visitedLand))
                    landToParse.Enqueue((x - 1, y));

                if (ValidCell(grid, x + 1, y, visitedLand))
                    landToParse.Enqueue((x + 1, y));

                if (ValidCell(grid, x, y - 1, visitedLand))
                    landToParse.Enqueue((x, y - 1));

                if (ValidCell(grid, x, y + 1, visitedLand))
                    landToParse.Enqueue((x, y + 1));
            }

        }

        private bool ValidCell(char[][] grid, int x, int y, HashSet<(int, int)> visitedLand)
        {
            if (x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length)
            {
                if (grid[x][y] == '1' && !visitedLand.Contains((x, y)))
                    return true;
            }
            return false;
        }


        // First Approach: combine hashset of all land with FLoodFill problem
        // too expensive memory wise.
        public int NumIslands1(char[][] grid)
        {
            // getting all land coordinates
            var existingLand = new HashSet<(int, int)>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                        existingLand.Add((i, j));
                }
            }

            int nIslands = 0;
            while (existingLand.Count > 0)
            {
                (int x, int y) = existingLand.First();
                ParseIslands1(grid, x, y, existingLand);
                nIslands++;
            }

            return nIslands;
        }



        // BFS
        private void ParseIslands1(char[][] grid, int initX, int initY, HashSet<(int, int)> allLand)
        {

            var pixelsToProcess = new Queue<(int, int)>(new[] { (initX, initY) });

            while (pixelsToProcess.Count > 0)
            {
                (int x, int y) = pixelsToProcess.Dequeue();
                allLand.Remove((x, y));

                // add valid neighbours
                if (allLand.Contains((x - 1, y)))
                    pixelsToProcess.Enqueue((x - 1, y));

                if (allLand.Contains((x + 1, y)))
                    pixelsToProcess.Enqueue((x + 1, y));

                if (allLand.Contains((x, y - 1)))
                    pixelsToProcess.Enqueue((x, y - 1));

                if (allLand.Contains((x, y + 1)))
                    pixelsToProcess.Enqueue((x, y + 1));

            }

        }

    }
}
