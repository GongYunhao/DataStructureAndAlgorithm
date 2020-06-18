using System;

namespace Leetcode
{
    public class RemoveDuplicatesFromSortedArray_26
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();
            if (nums.Length == 0)
                return 0;

            int leftIndex = 0;

            for (int i = 1; i <= nums.Length - 1; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[++leftIndex] = nums[i];
                }
            }

            return leftIndex + 1;
        }
    }
}
