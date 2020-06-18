using System;

namespace Leetcode
{
    public class NextPermutation_31
    {
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                throw new ArgumentException("The input array can't be null or empty", nameof(nums));
            if (nums.Length == 1)
                return;// 由于下面的程序需要判断逆序对，所以此处长度为1的数组需要排除出去

            // 从数组的末尾开始判断是否逆序对，如果是逆序对则向左移动一格，不停向左遍历直到找到一个正序对（或者越过数组起始位置）
            int leftIndex = nums.Length - 2;
            while (leftIndex >= 0 && nums[leftIndex] >= nums[leftIndex + 1])
            {
                leftIndex--;
            }

            if (leftIndex > -1)
            {
                // 找到第一个顺序对，此时leftIndex就对应的是顺序对中较小的那一个
                // 而从leftIndex+1开始向后的数组，仅包含逆序对，是需要完全翻转的
                // 但是题目要求是下一个排列组合数字，所以leftIndex需要修改，所以我们从逆序区域中寻找一个恰好大于leftIndex的数字，将这两者替换
                // 这样一来，不会破坏逆序区域内的逆序关系
                int i = nums.Length - 1;
                while (nums[i] <= nums[leftIndex])
                    i--;

                Swap(ref nums[leftIndex], ref nums[i]);
            }
            // 翻转leftIndex开始向后的数组，翻转完毕后这些数字是从小到大排序的
            // 如果leftIndex为-1，说明没有找到任何顺序对，也就需要翻转整个数组
            ReverseArray(nums, leftIndex + 1, nums.Length - 1);
        }

        private void ReverseArray(int[] nums, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                Swap(ref nums[startIndex], ref nums[endIndex]);
                startIndex++;
                endIndex--;
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
