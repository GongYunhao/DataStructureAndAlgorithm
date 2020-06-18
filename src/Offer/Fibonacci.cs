using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Offer
{
    public class FibonacciUsingMatrix
    {
        public static long Calculate(int n)
        {
            if (n == 0)
                return 0;

            SecondOrderMatrix origin = new SecondOrderMatrix(1, 1, 1, 0);
            SecondOrderMatrix singleUnit = new SecondOrderMatrix(1, 1, 1, 0);

            for (int i = 2; i < n; i++)
            {
                origin = origin * singleUnit;
            }

            return origin.GetFirstNumber();
        }
    }

    public class Fibonacci
    {
        public static long Calculate(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            long minusFirst = 1;
            long minusSecond = 0;
            long currentResult = 0;
            for (int i = 2; i <= n; i++)
            {
                currentResult = minusFirst + minusSecond;
                minusSecond = minusFirst;
                minusFirst = currentResult;
            }

            return currentResult;
        }
    }
}
