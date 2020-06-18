using System;

namespace Offer
{
    public class MaxPrice
    {
        public static int GetResult(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            int[,] result = new int[rowCount, columnCount];

            for (int i = rowCount - 1; i >= 0; i--)
            {
                for (int j = columnCount - 1; j >= 0; j--)
                {
                    result[i, j] = matrix[i, j];

                    int lower = 0;
                    if (i != rowCount - 1)
                        lower = result[i + 1, j];

                    int right = 0;
                    if (j != columnCount - 1)
                        right = result[i, j + 1];

                    result[i, j] += Math.Max(lower, right);
                }
            }

            return result[0, 0];
        }
    }
}
