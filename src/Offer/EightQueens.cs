using System;
using System.Diagnostics;

namespace Offer
{
    public class EightQueens
    {
        public static void GetResult()
        {
            Console.WriteLine("求解八皇后问题");

            Stopwatch s = Stopwatch.StartNew();
            // 八皇后问题最为直接的一个限制条件就是八个棋子在棋盘上的行列都不同
            // 可以用一个8个元素的数组模拟8列,数组中每个元素代表棋子所在的行数,总共是0-7
            // 这样二维的平面问题就转换成了求排序的问题
            // 可以求出所有的排序,然后针对一个排序,查看是否有两个棋子相互位于对角线上
            // 当所有结果遍历完成后,就可知八皇后问题解的数量
            int[] columnArray = { 0, 1, 2, 3, 4, 5, 6, 7 };

            int count = 0;
            Recursively(columnArray, 0, ref count);

            Console.WriteLine($"共{count}个解,计算使用了{s.Elapsed.TotalSeconds}秒");// 92个解,3ms完成计算
            Console.ReadKey();
        }

        private static void Recursively(int[] columnArray, int beginIndex, ref int count)
        {
            if (beginIndex == columnArray.Length - 1)
            {
                if (IsMatch(columnArray))
                    count++;
            }
            else
            {
                int i = beginIndex;
                for (; i <= columnArray.Length - 1; i++)
                {
                    int tmp = columnArray[beginIndex];
                    columnArray[beginIndex] = columnArray[i];
                    columnArray[i] = tmp;

                    Recursively(columnArray, beginIndex + 1, ref count);

                    tmp = columnArray[beginIndex];
                    columnArray[beginIndex] = columnArray[i];
                    columnArray[i] = tmp;
                }
            }
        }

        private static bool IsMatch(int[] columnArray)
        {
            for (int i = 0; i < columnArray.Length; i++)
            {
                for (int j = i + 1; j < columnArray.Length; j++)
                {
                    if (i - j == columnArray[i] - columnArray[j] ||
                        j - i == columnArray[i] - columnArray[j])
                        return false;
                }
            }

            return true;
        }
    }
}
