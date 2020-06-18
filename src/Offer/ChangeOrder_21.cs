using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class ChangeOrder
    {
        public static void Execute(int[] array)
        {
            Execute(array, i => (i & 1) == 1);
        }

        public static void Execute(int[] array, Func<int, bool> condition)
        {
            if (array == null || array.Length == 0)
                return;

            int left = 0, right = array.Length - 1;
            while (left < right)
            {
                while (left < right && condition(array[left]))
                    left++;

                while (left < right && !condition(array[right]))
                    right--;

                if (left < right)
                {
                    int tmp = array[left];
                    array[left] = array[right];
                    array[right] = tmp;
                }
            }
        }
    }
}
