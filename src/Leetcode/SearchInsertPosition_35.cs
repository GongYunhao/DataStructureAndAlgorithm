using System;

namespace Leetcode
{
    public class SearchInsertPosition_35
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums), "The input array can't be null");

            if (nums.Length == 0 || nums[0] >= target)
                return 0;

            if (nums[nums.Length - 1] < target)
                return nums.Length;

            int leftIndex = 0, rightIndex = nums.Length - 1;
            int middle = (leftIndex + rightIndex) / 2;

            while (true)
            {
                if (nums[middle] == target)
                    return middle;
                if (nums[middle + 1] == target || nums[middle] < target && nums[middle + 1] > target)
                    return middle + 1;

                if (nums[middle] < target)
                    leftIndex = middle;
                else
                    rightIndex = middle;
                middle = (leftIndex + rightIndex) / 2;
            }
        }
    }
}