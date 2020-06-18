namespace Leetcode
{
    public class UniquePathsII_63
    {
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            int rowCount = obstacleGrid.GetLength(0);
            int columnCount = obstacleGrid.GetLength(1);

            int[,] paths = new int[rowCount, columnCount];
            paths[rowCount - 1, columnCount - 1] = obstacleGrid[rowCount - 1, columnCount - 1] == 1 ? 0 : 1;

            for (int i = rowCount - 1; i >= 0; i--)
            {
                for (int j = columnCount - 1; j >= 0; j--)
                {
                    if (obstacleGrid[i, j] == 1)
                        continue;

                    if (i < rowCount - 1 && obstacleGrid[i + 1, j] == 0)
                        paths[i, j] += paths[i + 1, j];
                    if (j < columnCount - 1 && obstacleGrid[i, j + 1] == 0)
                        paths[i, j] += paths[i, j + 1];
                }
            }

            return paths[0, 0];
        }
    }
}
