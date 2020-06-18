using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class UniquePaths_62
    {
        // given m+n-2 slots, choose n-1 of them to operate downward, the others operate rightward
        // this is a Permutation and Combination problem
        public int UniquePaths(int m, int n)
        {
            if (m <= 0 || n <= 0)
                throw new ArgumentException();
            if (m == 1 || n == 1)
                return 1;

            HashSet<int> upper = new HashSet<int>();
            for (int i = 2; i <= m + n - 2; i++)
                upper.Add(i);

            HashSet<int> under = new HashSet<int>();
            if (m > n)
            {
                for (int i = 2; i <= m - 1; i++)
                    upper.Remove(i);
                for (int i = 2; i <= n - 1; i++)
                    under.Add(i);
            }
            else
            {
                for (int i = 2; i <= n - 1; i++)
                    upper.Remove(i);
                for (int i = 2; i <= m - 1; i++)
                    under.Add(i);
            }

            long result = 1;
            foreach (var item in upper)
            {
                result *= item;
            }

            long divided = 1;
            foreach (var item in under)
            {
                divided *= item;
            }

            return (int)(result / divided);
        }
    }
}
