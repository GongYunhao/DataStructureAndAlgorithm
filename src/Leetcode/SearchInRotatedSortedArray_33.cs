using System;

namespace Leetcode
{
    public class SearchInRotatedSortedArray_33
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums), "The input array can't be null");
            // 如果数组为空，不论target是多少结果都是-1
            if (nums.Length == 0)
                return -1;
            // 如果数组长度为1，则判断唯一元素和target的关系
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            // 如果数组的开始或末尾等于target，直接返回（真正原因是为了避免判断边界条件，如middle和middle+1是否越界）
            if (nums[0] == target)
                return 0;
            if (nums[nums.Length - 1] == target)
                return nums.Length - 1;

            int leftIndex = 0, rightIndex = nums.Length - 1;
            int middle = 0;

            if (nums[0] > nums[nums.Length - 1])
            {
                // 数组第一个元素大于末尾元素，表明当前数组经过旋转，需要二分找出数组中的分割点
                while (nums[middle] < nums[middle + 1])
                {
                    middle = (leftIndex + rightIndex) / 2;

                    if (nums[middle] > nums[0])
                        leftIndex = middle;
                    else
                        rightIndex = middle;
                }

                // 找到分割点后，判断target所在的区域，再次进行二分查找，这一次区域内的数字就是单调递增的
                if (target > nums[0])
                    return SearchInRange(nums, target, 0, middle);
                else
                    return SearchInRange(nums, target, middle + 1, nums.Length - 1);
            }
            else
            {
                // 数组未经过旋转，也就是数组在整个区域内单调递增，可以直接用二分法查找
                return SearchInRange(nums, target, 0, nums.Length - 1);
            }
        }

        private int SearchInRange(int[] nums, int target, int startIndex, int endIndex)
        {
            // 首先查看区域内首尾数字是否符合target要求，先期排除一部分情况
            if (nums[startIndex] > target || nums[endIndex] < target)
                return -1;

            int leftIndex = startIndex, rightIndex = endIndex;
            while (true)
            {
                int middle = (leftIndex + rightIndex) / 2;

                // 由于上面求中点的公式限制，middle是不能取到endIndex值的，所以需要middle+1辅助判断
                // 当遇到任意一个值等于target的时候就可以返回了
                if (nums[middle] == target)
                    return middle;
                if (nums[middle + 1] == target)
                    return middle + 1;

                // target并不存在于数组中
                if (nums[middle] < target && nums[middle + 1] > target)
                    return -1;

                if (nums[middle] < target)
                    leftIndex = middle;
                else
                    rightIndex = middle;
            }
        }
    }
}
