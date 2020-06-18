using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class RotatedArray
    {
        public static int FindMin(int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("The given array can't be null or empty", nameof(array));

            int startIndex = 0;
            int endIndex = array.Length - 1;

            // 针对数组没有旋转的情况
            if (array[startIndex] < array[endIndex])
                return array[startIndex];

            // 已旋转过的数组,使用二分法查找最小值
            while (startIndex != endIndex - 1)
            {
                int middlePoint = (startIndex + endIndex) / 2;

                // 起始位置,中间位置,结束位置的值都一致,此时无法判断最小值在哪个区间,只能遍历查找
                if (array[startIndex] == array[middlePoint] && array[startIndex] == array[endIndex])
                {
                    return FindMinByTraversing(array, startIndex, endIndex);
                }

                // 此段需要综合考虑起始位置和结束位置的值相对大小:
                // 1.起始位置小于结束位置==>数组没有旋转,已在while循环前处理
                // 2.起始位置等于结束位置==>数组有旋转,但是旋转的分界点两侧值一致:只需要考虑中间位置的值大于或小于(等于的情况已处理过)两端的情况
                // 3.起始位置大于结束位置==>数组正常旋转,并且中间位置值可以大于等于起始位置/小于等于结束位置
                if (array[middlePoint] >= array[startIndex])
                {
                    startIndex = middlePoint;
                }
                else if (array[middlePoint] <= array[endIndex])
                {
                    endIndex = middlePoint;
                }
            }

            return array[endIndex];
        }

        private static int FindMinByTraversing(int[] array, int startIndex, int endIndex)
        {
            int result = array[startIndex];
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (array[i] <= result)
                    result = array[i];
            }

            return result;
        }
    }
}
