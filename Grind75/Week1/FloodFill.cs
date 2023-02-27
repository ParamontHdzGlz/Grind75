using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    internal class FloodFillClass
    {
        // This is faster
        public int[][] FloodFill(int[][] image, int sr, int sc, int color, int? originalColor = null)
        {
            if (!originalColor.HasValue)
                originalColor = image[sr][sc];

            if (sr < 0 || sc < 0 || sr >= image.Length || sc >= image[0].Length)
                return image;
            if (image[sr][sc] != originalColor || image[sr][sc] == color)
                return image;

            image[sr][sc] = color;

            image = FloodFill(image, sr - 1, sc, color, originalColor);
            image = FloodFill(image, sr + 1, sc, color, originalColor);
            image = FloodFill(image, sr, sc - 1, color, originalColor);
            image = FloodFill(image, sr, sc + 1, color, originalColor);

            return image;
        }


        // This is slower
        public int[][] FloodFill_usingQueue(int[][] image, int sr, int sc, int color)
        {
            int originalColor = image[sr][sc];
            if (color == originalColor) return image;

            var pixelsToProcess = new Queue<(int, int)>(new[] { (sr, sc) });

            while (pixelsToProcess.Count > 0)
            {
                (int i, int j) = pixelsToProcess.Dequeue();

                // add valid neighbours
                if (ValidPixel(image, i - 1, j, color, originalColor))
                    pixelsToProcess.Enqueue((i - 1, j));

                if (ValidPixel(image, i + 1, j, color, originalColor))
                    pixelsToProcess.Enqueue((i + 1, j));

                if (ValidPixel(image, i, j - 1, color, originalColor))
                    pixelsToProcess.Enqueue((i, j - 1));

                if (ValidPixel(image, i, j + 1, color, originalColor))
                    pixelsToProcess.Enqueue((i, j + 1));

                image[i][j] = color;
            }


            return image;
        }


        private bool ValidPixel(int[][] image, int sr, int sc, int color, int originalColor)
        {
            // valid coordenates
            if (sr >= 0 && sc >= 0 && sr < image.Length && sc < image[0].Length)
            {
                // valid color condition
                if (image[sr][sc] == originalColor )
                    return true;
            }

            return false;
        }
    }
}
