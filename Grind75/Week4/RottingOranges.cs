using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    internal class RottingOranges
    {
        public int OrangesRotting(int[][] grid)
        {
            var rotQueue = new Queue<(int, int)>();
            var freshSet = new HashSet<(int, int)>();
            // get the initially rotten oranges, plus set of fresh ones
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                        rotQueue.Enqueue((i, j));
                    else if (grid[i][j] == 1)
                        freshSet.Add((i, j));
                }
            }

            int time = 2;
            var directions = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            // using BFS, rot subsequent oranges, also adding the time it took them to rot
            while (rotQueue.Count > 0)
            {
                (int x, int y) = rotQueue.Dequeue();

                foreach ((int xD, int yD) in directions)
                {
                    int newX = x + xD;
                    int newY = y + yD;
                    if (newX >= 0 && newX < grid.Length && newY >= 0 && newY < grid[0].Length)
                    {
                        if (grid[newX][newY] == 1)
                        {
                            freshSet.Remove((newX, newY));
                            grid[newX][newY] = grid[x][y] + 1;
                            time = Math.Max(time, grid[newX][newY]);
                            rotQueue.Enqueue((newX, newY));
                        }
                    }
                }
            }

            /*
            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine(string.Join(",", grid[i]));
            }
            */
            if (freshSet.Count > 0) return -1;

            return time - 2;
        }
    }
}
