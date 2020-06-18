using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class ThreeSum_15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();
            if (nums.Length < 3)
                return new List<IList<int>>();

            IList<IList<int>> resultList = new List<IList<int>>();
            Array.Sort(nums);
            ThreeSumCore(nums, 0, resultList);
            return resultList;
        }

        private void ThreeSumCore(int[] nums, int target, IList<IList<int>> resultList)
        {
            for (int i = 0; i <= nums.Length - 3; i++)
            {
                TwoSum(nums, i + 1, target - nums[i], resultList, nums[i]);

                // 这里包含了一个陷阱，即数组中存在重复元素的情况
                // 选定过重复元素中的第一个后，下面的TwoSum函数会包含所有含有该元素的组合，无论是一个还是两个三个
                // 所以下一次计算的时候，需要完全排除掉这个重复元素
                // 这相当于两种情况：有该重复元素（无论个数），没有该重复元素（0个）
                while (i < nums.Length - 2 && nums[i] == nums[i + 1])
                    i++;
            }
        }

        private void TwoSum(int[] nums, int startIndex, int target, IList<IList<int>> resultList, int tmpResult)
        {
            int leftIndex = startIndex;
            int rightIndex = nums.Length - 1;

            while (leftIndex < rightIndex)
            {
                if (nums[leftIndex] + nums[rightIndex] < target)
                    leftIndex++;
                else if (nums[leftIndex] + nums[rightIndex] > target)
                    rightIndex--;
                else
                {
                    resultList.Add(new[] { tmpResult, nums[leftIndex], nums[rightIndex] });

                    while (leftIndex < rightIndex && nums[leftIndex] == nums[leftIndex + 1])
                        leftIndex++;

                    leftIndex++;
                }
            }
        }
    }
}
