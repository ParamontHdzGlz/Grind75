using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int upLimit = 0;
            int downLimit = matrix.Length - 1;
            int leftLimit = 0;
            int rightLimit = matrix[0].Length - 1;

            var movements = new Dictionary<string, Func<(int x, int y), (int x, int y)>>
            {
                {"right",  (coor => (coor.x, coor.y + 1)) }, // right
                {"down",  (coor => (coor.x + 1, coor.y)) }, // down
                {"left", (coor => (coor.x, coor.y - 1)) }, // left
                {"up", (coor => (coor.x - 1, coor.y)) } // up
            };


            (int x, int y) currPos = (0, 0);
            var currMov = "right";

            var res = new List<int>(matrix.Length * matrix[0].Length);
            while (upLimit <= downLimit && leftLimit <= rightLimit)
            {
                switch (currMov)
                {
                    case "right":
                        while (currPos.y < rightLimit)
                        {
                            res.Add(matrix[currPos.x][currPos.y]);
                            currPos = movements[currMov](currPos);
                        }
                        currMov = "down";
                        upLimit++;
                        break;
                    case "down":
                        while (currPos.x < downLimit)
                        {
                            res.Add(matrix[currPos.x][currPos.y]);
                            currPos = movements[currMov](currPos);
                        }
                        currMov = "left";
                        rightLimit--;
                        break;
                    case "left":
                        while (currPos.y > leftLimit)
                        {
                            res.Add(matrix[currPos.x][currPos.y]);
                            currPos = movements[currMov](currPos);
                        }
                        currMov = "up";
                        downLimit--;
                        break;
                    case "up":
                        while (currPos.x > upLimit)
                        {
                            res.Add(matrix[currPos.x][currPos.y]);
                            currPos = movements[currMov](currPos);
                        }
                        leftLimit++;
                        currMov = "right";
                        break;
                }
            }
            res.Add(matrix[currPos.x][currPos.y]);

            return res;
        }
    }
}
