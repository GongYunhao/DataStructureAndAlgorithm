using System;

namespace Leetcode
{
    public class ThreeSumClosest_16
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentNullException();
            if (nums.Length < 3)
                throw new ArgumentException();

            Array.Sort(nums);
            int result = nums[0] + nums[1] + nums[2];// 有溢出风险，用long比较保险

            ThreeSumCore(nums, target, ref result);
            return result;
        }

        private void ThreeSumCore(int[] nums, int target, ref int result)
        {
            for (int i = 0; i <= nums.Length - 3; i++)
            {
                int leftIndex = i + 1;
                int rightIndex = nums.Length - 1;

                while (leftIndex < rightIndex)
                {
                    int sum = nums[leftIndex] + nums[rightIndex] + nums[i];

                    if (Math.Abs(sum - target) < Math.Abs(result - target))
                    {
                        result = sum;
                    }


                    if (nums[leftIndex] + nums[rightIndex] < target - nums[i])
                    {
                        leftIndex++;
                    }
                    else if (nums[leftIndex] + nums[rightIndex] > target - nums[i])
                    {
                        rightIndex--;
                    }
                    else
                    {
                        result = target;
                        return;
                    }
                }
            }
        }
    }
}
