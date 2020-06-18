using System;

namespace Leetcode
{
    public class SqrtX_69
    {
        public int MySqrt(int x)
        {
            if (x < 0)
                throw new ArgumentNullException();

            // left start point is obvious
            // right point should be the biggest num whose square is within int range(sqrt(0x7FFFFFFF))
            // however, in order to perform dichotomy, it is essential that the left int could go to that value
            // so, i decided to make right = biggest + 1, don't worry, since middle = (left + right) / 2, the left will never get same value as right
            int left = 0, right = 46341;

            // use dichotomy method
            while (left != right - 1)
            {
                int middle = (left + right) / 2;

                int square = middle * middle;
                if (square == x)
                {
                    left = middle;
                    break;
                }
                else if (square < x)
                    left = middle;
                else
                    right = middle;
            }

            return left;
        }
    }
}
