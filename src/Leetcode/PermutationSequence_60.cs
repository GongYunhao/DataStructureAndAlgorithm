using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class PermutationSequence_60
    {
        // this array could be written inline or generated on starting the program
        private static int[] _factorial = { 0, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

        // take n=3 as example, we can put them in order:1,2,3
        // suppose k is no more than 2, then the first digit of 1 will not be changed
        // we can also get other situations:
        // if 2<k<=4, then the first digit is 2; 4<k<=6, digit 3 is the first
        // so we can use a 'for' loop to get result and each loop will calculate one digit
        // we also use an bool[] to mark which digit is already in use, so that result will never be duplicated
        public string GetPermutation(int n, int k)
        {
            if (k > _factorial[n])
                throw new ArgumentException();

            k--;// if k starts from 0, it is much more convenient to operate division on k

            char[] result = new char[n];
            bool[] used = new bool[n];

            for (int i = 0; i < n - 1; i++)
            {
                int rounds = k / _factorial[n - 1 - i];// work out which round that current k is at
                k %= _factorial[n - 1 - i];

                result[i] = (char)(GetUnusedIntById(used, rounds) + '0');
            }

            // when it comes to the last digit, there is only one option to choose from(also prevents 'divide by zero' problem)
            result[n - 1] = (char)(GetUnusedIntById(used, 0) + '0');
            return new string(result);
        }

        // get count-st not-in-use digit
        // e.g. when n=3, and digit 1 is already in use
        // let count = 2, the return value should be 3, since the digit 3 is the 2st available value
        private int GetUnusedIntById(bool[] used, int count)
        {
            int index = -1;

            while (count >= 0)
            {
                index++;

                if (used[index])
                    continue;
                else
                {
                    count--;
                }
            }

            used[index] = true;
            return index + 1;
        }
    }
}
