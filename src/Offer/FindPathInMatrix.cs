using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class FindPathInMatrix
    {
        public static bool HasPath(char[,] matrix, string target)
        {
            if (matrix == null || matrix.Length == 0)
                throw new ArgumentException("The input matrix can't be null or empty", nameof(matrix));
            if (String.IsNullOrEmpty(target))
                throw new ArgumentException("The input string can't be null or empty", nameof(target));

            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            bool result = false;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (matrix[i, j] == target[0])
                    {
                        // 查找到回溯算法起点
                        result |= FindPath(matrix, rowCount, columnCount, i, j, target, new bool[rowCount, columnCount], 0);
                    }
                }
            }

            return result;
        }

        private static bool FindPath(char[,] matrix, int rowCount, int columnCount, int i, int j, string target, bool[,] visited, int level)
        {
            // 超出边界或者当前元素标记为已访问
            if (i < 0 || i >= rowCount || j < 0 || j >= columnCount || visited[i, j])
            {
                return false;
            }
            // 字符不匹配时直接返回false
            if (matrix[i, j] != target[level])
            {
                return false;
            }
            // 当到达字符串的结尾,并且字符匹配时,将当前矩阵元素标记为已访问,并返回true
            if (level == target.Length - 1 && matrix[i, j] == target[level])
            {
                visited[i, j] = true;
                return true;
            }

            // 当前元素设置为已访问,这样下面四个子路径就不会重复访问本元素
            visited[i, j] = true;
            // 测试上下左右四个元素,以及由它们作为起点延伸出去的路径
            bool findResult =
                FindPath(matrix, rowCount, columnCount, i - 1, j, target, visited, level + 1) ||
                FindPath(matrix, rowCount, columnCount, i + 1, j, target, visited, level + 1) ||
                FindPath(matrix, rowCount, columnCount, i, j - 1, target, visited, level + 1) ||
                FindPath(matrix, rowCount, columnCount, i, j + 1, target, visited, level + 1);

            if (!findResult)
            {
                // 如果当前元素的四个方向都没有找到有效路径,应当返回上一层
                // 返回前,将当前节点设置为未访问
                visited[i, j] = false;
            }

            return findResult;
        }
    }
}
