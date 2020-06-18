using System;

namespace Leetcode
{
    public class MinimumPathSum_64
    {
        public int MinPathSum(int[,] grid)
        {
            if (grid == null)
                throw new ArgumentNullException();
            if (grid.Length == 0)
                throw new ArgumentException();

            int rowCount = grid.GetLength(0);
            int columnCount = grid.GetLength(1);

            // assume we can edit ints in the grid
            // if can't, then another int[] is needed to save temp result
            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < columnCount; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;

                    else if (j == 0)
                        grid[i, j] += grid[i - 1, j];
                    else if (i == 0)
                        grid[i, j] += grid[i, j - 1];
                    else
                        grid[i, j] += Math.Min(grid[i, j - 1], grid[i - 1, j]);
                }
            }

            return grid[rowCount - 1, columnCount - 1];
        }
    }
}
