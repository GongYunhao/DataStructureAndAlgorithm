using System;

namespace Offer
{
    public class InterpretResultsCount
    {
        public static int Calculate(int num)
        {
            if (num < 0)
                throw new ArgumentException();

            //return CalculateRecursively(num.ToString(), 0);
            return CalculateRecursively(num.ToString());
        }

        // 这种做法会导致重复的子问题,时间效率还可以再优化
        private static int CalculateRecursively(string text, int offset)
        {
            if (offset == text.Length)
                return 1;

            int count = 0;
            if (offset <= text.Length - 1)
                count += CalculateRecursively(text, offset + 1);
            if (offset <= text.Length - 2 && CanBeInterpreted(text, offset))
                count += CalculateRecursively(text, offset + 2);

            return count;
        }

        // 这种做法从数字的最右侧向左求解,避免了重复子问题,但是要额外占据一个数组的内存空间
        // 而且在设定初始条件时,需要用到两个数组元素位置(不用两个元素也可以,但是要考虑边界条件),对于单个数字需要额外的处理
        private static int CalculateRecursively(string text)
        {
            int[] result = new int[text.Length];
            result[text.Length - 1] = 1;// 最后一个字符,只有一种翻译方法
            if (text.Length >= 2)// 针对单个数字的情况,不需要设定倒数第二个数组元素的初始条件
                result[text.Length - 2] = CanBeInterpreted(text, text.Length - 2) ? 2 : 1;// 倒数两个字符,分开翻译是一种情况,还需要查看是否可以合起来翻译

            for (int i = text.Length - 3; i >= 0; i--)
            {
                // 元素i处的值,等于左侧相邻元素的值(单个字符翻译的情况),加上左侧第二个元素的值(两个字符可以合起来翻译)
                result[i] = result[i + 1];
                if (CanBeInterpreted(text, i))
                    result[i] += result[i + 2];
            }

            return result[0];
        }

        private static bool CanBeInterpreted(string text, int offset)
        {
            return text[offset] == '0'
                   || text[offset] == '1'
                   || text[offset] == '2' && text[offset + 1] >= '0' && text[offset + 1] <= '5';
        }
    }
}
