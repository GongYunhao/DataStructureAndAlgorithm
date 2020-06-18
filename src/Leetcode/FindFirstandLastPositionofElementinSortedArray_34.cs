using System;

namespace Leetcode
{
    public class FindFirstAndLastPositionOfElementInSortedArray_34
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentException($"The input array '{nameof(nums)}' can't be null or empty", nameof(nums));

            // 由于数组是经过排序的，所以测试数组的头尾与target的关系可以先期排除掉一些数据
            if (nums.Length == 0 || nums[0] > target || nums[nums.Length - 1] < target)
                return new[] { -1, -1 };

            // 由于下面的边界条件需要判断middle和middle+1，所以数组中只有一个元素是无法判断的，可以作为特殊情况返回
            if (nums.Length == 1 && nums[0] == target)
                return new[] { 0, 0 };

            int leftResult, rightResult;

            // 寻找target区间的左边界
            int leftIndex = 0, rightIndex = nums.Length - 1;
            int middle = (leftIndex + rightIndex) / 2;
            while (true)
            {
                if (middle == 0 && nums[middle] == target)// 边界条件1：数组的第一个元素就是target
                {
                    leftResult = middle;
                    break;
                }

                if (nums[middle] < target && nums[middle + 1] == target)// 边界条件2：middle恰好位于target区域的分界点上
                {
                    leftResult = middle + 1;
                    break;
                }

                if (nums[middle] < target && nums[middle + 1] > target)// 边界条件3：发现数组中不存在target值
                {
                    return new[] { -1, -1 };
                }

                if (nums[middle] < target)
                    leftIndex = middle;
                else
                    rightIndex = middle;

                middle = (leftIndex + rightIndex) / 2;
            }

            // 寻找target区间的右边界
            leftIndex = 0;
            rightIndex = nums.Length - 1;
            middle = (leftIndex + rightIndex) / 2;
            while (true)
            {
                if (middle == nums.Length - 2 && nums[middle + 1] == target)// 边界条件1：数组的最后一个元素是target
                {
                    rightResult = middle + 1;
                    break;
                }

                if (nums[middle] == target && nums[middle + 1] > target)// 边界条件2：middle恰好位于target区域的分界点上
                {
                    rightResult = middle;
                    break;
                }

                // 数组中不包含target的情况前面已经处理，此处不需要再判断

                if (nums[middle] <= target)
                    leftIndex = middle;
                else
                    rightIndex = middle;

                middle = (leftIndex + rightIndex) / 2;
            }

            return new[] { leftResult, rightResult };
        }
    }
}
