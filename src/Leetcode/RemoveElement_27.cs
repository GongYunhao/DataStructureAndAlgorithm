using System;

namespace Leetcode
{
    public class RemoveElement_27
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null)
                throw new ArgumentNullException();
            if (nums.Length == 0)
                return 0;

            int valCount = 0;// 记录已经遍历到的val数量，当i遇到非val的值时，就将这个值向前移动valCount个位置
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    valCount++;
                    continue;
                }
                if (valCount > 0)
                {
                    nums[i - valCount] = nums[i];
                }
            }

            return nums.Length - valCount;
        }
    }
}
