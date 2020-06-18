using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public sealed class FindNumInMatrix
    {
        public static Boolean Execute(int[] matrix, int rowCount, int columnCount, int numToFind)
        {
            // 异常情况处理
            if (matrix == null)
                throw new NullReferenceException("The array can't be null");
            if (matrix.Length < rowCount * columnCount)
                throw new ArgumentException("Parameter rowCount/columnCount doesn't match the given matrix");

            // 从矩阵的右上角开始,比对当前值和目标值的大小关系
            // 若当前值大于目标值,则可以剔除掉当前值所在的列,因为列中所有元素都大于当前值
            // 同理当前值小于目标值时,可以剔除掉行(如果换用左上角/右下角就不行,因为剩余的所有值与当前值的大小关系是一致的,无法缩小目标区域)
            // 当前值等于目标值时,即返回true,表明找到了结果;或者遍历整个矩阵都没有结果时,返回false

            // 从矩阵的右上角开始
            int currentRowIndex = 0;
            int currentColumnIndex = columnCount - 1;

            while (currentRowIndex < rowCount && currentColumnIndex >= 0)
            {
                int currentNum = matrix[rowCount * currentColumnIndex + currentRowIndex];// 第一次写代码的时候,多加了1,忽略了数组是从0开始的
                if (numToFind < currentNum)
                    currentColumnIndex--;
                else if (numToFind > currentNum)
                    currentRowIndex++;
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
