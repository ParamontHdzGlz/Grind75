using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class Matrix01
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            int nRows = mat.Length;
            int nCols = mat[0].Length;
            Queue<(int row, int col)> queue = new Queue<(int, int)>();

            // get all 0 coordinates and mark non zeros as -1
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    if (mat[i][j] == 0)
                        queue.Enqueue((i, j));
                    else
                        mat[i][j] = -1; // mark cell as unprocessed
                }
            }


            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                for (int state = 0; state < 4; state++)
                {
                    var nextCell = NeighbourCoordinate(state, cell);

                    if (nextCell.row < 0 || nextCell.row >= nRows ||
                        nextCell.col < 0 || nextCell.col >= nCols ||
                        mat[nextCell.row][nextCell.col] != -1)
                        continue;

                    mat[nextCell.row][nextCell.col] = mat[cell.row][cell.col] + 1;

                    queue.Enqueue(nextCell);
                }
            }

            return mat;
        }

        private (int row, int col) NeighbourCoordinate(int state, (int row, int col) cell)
        {
            switch (state)
            {
                case 0:
                    return (cell.row + 1, cell.col);
                case 1:
                    return (cell.row, cell.col + 1);
                case 2:
                    return (cell.row - 1, cell.col);
                case 3:
                    return (cell.row, cell.col - 1);
                default:
                    throw new ArgumentException();
            }
        }

    }
}
