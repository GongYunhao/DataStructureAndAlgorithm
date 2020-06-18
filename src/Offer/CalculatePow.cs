using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class CalculatePow
    {
        public static double Power(double baseNum, int exponent)
        {
            if ((decimal)baseNum == 0 && exponent <= 0)
                throw new ArgumentException("Can't calculate.");

            bool isExponentUnderZero = exponent < 0;
            uint absExponent = isExponentUnderZero ? (uint)-exponent : (uint)exponent;
            double result = CalculatePowWithAbsoluteExponent(baseNum, absExponent);

            return isExponentUnderZero ? 1 / result : result;
        }

        private static double CalculatePowWithAbsoluteExponent(double baseNum, uint exponent)
        {
            if (exponent == 0)
                return 1;

            double result = CalculatePowWithAbsoluteExponent(baseNum, exponent >> 1);// 乘方数除以二,计算结果(抛弃掉末尾的1)
            result *= result;// 计算原始乘方数(抛弃掉末尾的1)
            if ((exponent & 0x00000001) == 1)// 查看乘方数最后一位,如果是1,则另外再乘上一个基数
                result *= baseNum;
            return result;
        }
    }
}
