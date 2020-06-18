using System;

namespace Leetcode
{
    public class MultiplyStrings_43
    {
        private const string ZeroResult = "0";

        // 解答可参考项目文件夹下43. Multiply Strings.jpg
        public string Multiply(string num1, string num2)
        {
            if (string.IsNullOrWhiteSpace(num1) || string.IsNullOrWhiteSpace(num2) || num1 == string.Empty || num2 == string.Empty)
                throw new ArgumentException("The input string can't be null or empty");

            if (IsStringAllZero(num1) || IsStringAllZero(num2))
                return ZeroResult;

            char[] result = new char[num1.Length + num2.Length];
            int resultIndex = 0;
            for (; resultIndex < result.Length; resultIndex++)
                result[resultIndex] = '0';

            // 保存相加时的进位
            int carry = 0;

            for (int currentSum = num1.Length + num2.Length - 2; currentSum >= 0; currentSum--)
            {
                int indexNum1, indexNum2;

                // 将num1的指针尽量向右移动，如果超过了num1的长度，开始移动num2的指针
                // 因为后面需要两个指针分别向左向右移动，所以此处需要移动到所有可能位置的尽头，这样在后面while循环中才能遍历到所有的值
                if (currentSum > num1.Length - 1)
                {
                    indexNum1 = num1.Length - 1;
                    indexNum2 = currentSum - indexNum1;
                }
                else
                {
                    indexNum1 = currentSum;
                    indexNum2 = 0;
                }

                while (indexNum1 >= 0 && indexNum2 <= num2.Length - 1)
                {
                    carry += (num1[indexNum1] - '0') * (num2[indexNum2] - '0');

                    indexNum1--;
                    indexNum2++;
                }

                result[--resultIndex] = (char)(carry % 10 + '0');// 从数组的末尾开始赋值
                carry = carry / 10;
            }

            // 对于两个乘数最高位相乘大于等于10的情况，上面的循环结束时进位数仍有剩余，需要额外添加一次赋值
            if (carry > 0)
                result[--resultIndex] = (char)(carry + '0');

            return new string(result, resultIndex, result.Length - resultIndex);// 如果字符串开头有0，需要去除
        }

        private bool IsStringAllZero(string str)
        {
            foreach (var c in str)
            {
                if (c != '0')
                    return false;
            }

            return true;
        }
    }
}
