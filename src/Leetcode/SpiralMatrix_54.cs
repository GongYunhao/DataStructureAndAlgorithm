using System.Collections.Generic;

namespace Leetcode
{
    public class SpiralMatrix_54
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            IList<int> result = new List<int>();
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            SpiralOrderCore(matrix, result, 0, rowCount - 1, 0, columnCount - 1);

            return result;
        }

        private void SpiralOrderCore(int[,] matrix, IList<int> result, int rowStartIndex, int rowEndIndex, int columnStartIndex, int columnEndIndex)
        {
            // Add upper margin
            for (int i = columnStartIndex; i <= columnEndIndex; i++)
                result.Add(matrix[rowStartIndex, i]);

            // Right margin
            for (int i = rowStartIndex + 1; i <= rowEndIndex; i++)
                result.Add(matrix[i, columnEndIndex]);

            // buttom margin
            if (rowEndIndex > rowStartIndex)
                for (int i = columnEndIndex - 1; i >= columnStartIndex; i--)
                    result.Add(matrix[rowEndIndex, i]);

            // left margin
            if (columnEndIndex > columnStartIndex)
                for (int i = rowEndIndex - 1; i >= rowStartIndex + 1; i--)
                    result.Add(matrix[i, columnStartIndex]);

            if (rowEndIndex - rowStartIndex >= 2 && columnEndIndex - columnStartIndex >= 2)
                SpiralOrderCore(matrix, result, rowStartIndex + 1, rowEndIndex - 1, columnStartIndex + 1, columnEndIndex - 1);
        }
    }
}
