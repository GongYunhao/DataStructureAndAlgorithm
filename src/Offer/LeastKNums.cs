using System;
using System.Collections.Generic;
using System.Linq;

namespace Offer
{
    public class LeastKNums
    {
        public static int[] GetResult(int[] array, int k)
        {
            if (array == null || array.Length < k)
                throw new ArgumentException();

            int index = 0;
            SortedSet<int> set = new SortedSet<int>();// 注意该类型不支持重复元素,如果一定要支持重复元素,应该用SortedDictionary,value对应该元素出现的次数

            while (set.Count < k)
            {
                set.Add(array[index]);
                index++;
            }

            for (; index <= array.Length - 1; index++)
            {
                if (set.Max <= array[index])
                    continue;
                set.Remove(set.Max);
                set.Add(array[index]);
            }

            return set.ToArray();
        }
    }
}
