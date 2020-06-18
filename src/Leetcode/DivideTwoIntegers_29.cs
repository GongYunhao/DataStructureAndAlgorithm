using System;

namespace Leetcode
{
    public class DivideTwoIntegers_29
    {
        public int Divide(int dividend, int divisor)
        {
            //Reduce the problem to positive long integer to make it easier.
            //Use long to avoid integer overflow cases.
            int sign = dividend > 0 ^ divisor > 0 ? -1 : 1;

            long ldividend = Math.Abs((long)dividend);
            long ldivisor = Math.Abs((long)divisor);

            //Take care the edge cases.
            if (ldivisor == 0)
                return int.MaxValue;
            if ((ldividend == 0) || (ldividend < ldivisor))
                return 0;

            long lans = ldivide(ldividend, ldivisor);

            int ans;
            if (lans > int.MaxValue)
            {
                //Handle overflow.
                ans = sign == 1 ? int.MaxValue : int.MinValue;
            }
            else
            {
                ans = (int)(sign * lans);
            }
            return ans;
        }

        private long ldivide(long ldividend, long ldivisor)
        {
            // 基准情况：当被除数小于除数的时候，连一次计算就不能支撑了，只能返回0
            if (ldividend < ldivisor)
                return 0;

            // 循环将除数*2，直到下一次处理后将大于被除数，记录此时的数字以及总的被除数数量
            long sum = ldivisor;
            long multiple = 1;
            while (sum + sum <= ldividend)
            {
                sum += sum;
                multiple += multiple;
            }
            // 此轮的被除数数量+剩余数字递归计算后返回的值，相当于总的计算结果
            return multiple + ldivide(ldividend - sum, ldivisor);
        }
    }
}
