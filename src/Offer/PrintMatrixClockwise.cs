using System.Text;

namespace Offer
{
    public class PrintMatrixClockwise
    {
        public static string GetTotalResult(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            GetPrintResult(matrix, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1, sb);
            return sb.ToString(0, sb.Length - 1);
        }

        private static void GetPrintResult(int[,] matrix, int rowStartIndex, int rowEndIndex, int columnStartIndex,
            int columnEndIndex, StringBuilder sb)
        {
            int currentRowIndex = rowStartIndex;
            int currentColumnIndex = columnStartIndex - 1;

            while (currentColumnIndex < columnEndIndex)
            {
                currentColumnIndex++;
                sb.Append(matrix[currentRowIndex, currentColumnIndex]).Append(",");
            }

            while (currentRowIndex < rowEndIndex)
            {
                currentRowIndex++;
                sb.Append(matrix[currentRowIndex, currentColumnIndex]).Append(",");
            }

            // 如果矩阵只有一行,则不需要横向返回的遍历
            if (rowStartIndex != rowEndIndex)
            {
                while (currentColumnIndex > columnStartIndex)
                {
                    currentColumnIndex--;
                    sb.Append(matrix[currentRowIndex, currentColumnIndex]).Append(",");
                }
            }

            // 如果矩阵只有一列,不需要纵向返回
            if (columnStartIndex != columnEndIndex)
            {
                while (currentRowIndex > rowStartIndex + 1)
                {
                    currentRowIndex--;
                    sb.Append(matrix[currentRowIndex, currentColumnIndex]).Append(",");
                }
            }

            if (rowEndIndex - rowStartIndex >= 2 && columnEndIndex - columnStartIndex >= 2)
            {
                // 去掉最外边一圈,遍历中间的矩阵元素
                GetPrintResult(matrix,
                    rowStartIndex + 1, rowEndIndex - 1,
                    columnStartIndex + 1, columnEndIndex - 1, sb);
            }
        }
    }
}
