using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public class Search2DMatrix_74
    {
        private int _rowCount;
        private int _columnCount;

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            _rowCount = matrix.Length;
            _columnCount = matrix[0].Length;

            if (matrix[0][0] > target || matrix[_rowCount - 1][_columnCount - 1] < target)
                return false;

            int startIndex = 0, endIndex = _rowCount * _columnCount - 1;
            int middle;
            while (startIndex <= endIndex)
            {
                if (GetValueByIndex(matrix, startIndex) == target || GetValueByIndex(matrix, endIndex) == target)
                    return true;

                middle = (startIndex + endIndex) / 2;
                int middleInt = GetValueByIndex(matrix, middle);
                if (middleInt == target)
                    return true;

                if (middleInt < target)
                    startIndex = middle + 1;
                else
                    endIndex = middle - 1;
            }

            return false;
        }

        private int GetValueByIndex(int[][] matrix, int index)
        {
            return matrix[index / _columnCount][index % _columnCount];
        }
    }
}
