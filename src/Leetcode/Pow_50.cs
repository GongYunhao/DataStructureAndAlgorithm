namespace Leetcode
{
    public class Pow_50
    {
        // 计算乘方结果
        // 底数取值范围: -100.0 < x < 100.0
        // 指数n是一个32位的有符号int,取值范围[−2^31, 2^31 − 1]
        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;// 指数为0的情况,可以直接返回结果(或者也可以在第一个while循环中,当currentBit变成0,循环都没有结束,说明n的二进制表达不包含'1',所以不能按照下面的二分法来快捷计算)
            
            bool isExponentMinValue = n == int.MinValue;// 判断n是否是int类型的最小值,即0x80000000,由于下面需要抛开符号计算,如果强行取反得到结果还是0x80000000
            if (isExponentMinValue)
                n++;// 曲线一下,这样才能顺利转换到0至int.maxvalue区间内

            bool isExponentUnderZero = n < 0;// 判断指数是否小于0,如果小于0,那么在最后返回结果时需要用1去除结果
            if (isExponentUnderZero)
                n = -n;

            // 设定最高位为1,右移直到发现n中的第一个二进制'1'
            uint currentBit = 0x80000000;
            while ((currentBit & n) == 0)
            {
                currentBit >>= 1;
            }

            // 从指数n的最高位'1'开始,每发现一个1,就给最终结果乘上一个底数;同时每一次右移,代表指数大小乘以2,对应到结果就是计算平方
            double result = 1;
            while (currentBit > 0)
            {
                if ((currentBit & n) != 0)
                    result *= x;

                currentBit >>= 1;

                if (currentBit != 0)
                    result *= result;
            }

            if (isExponentMinValue)
                result *= x;// 之前为了顺利转换从指数(这里指绝对值)上减去了一,反映到结果中就是少乘一次底数,这里补上
            if (isExponentUnderZero)
                result = 1 / result;// 若原本的指数小于0,返回结果需要用1去除
            return result;
        }
    }
}
