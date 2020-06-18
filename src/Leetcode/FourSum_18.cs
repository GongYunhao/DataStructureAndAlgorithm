using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class FourSum_18
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> result = Sum(nums, target, 4, 0);

            return result;
        }

        /// <summary>
        /// 计算任意数量的数字之和，将所有符合条件的集合作为一个整体返回
        /// </summary>
        /// <param name="sortedNums">排序数组</param>
        /// <param name="target">目标数值</param>
        /// <param name="sumLength">总共需要的数字数量</param>
        /// <param name="index">查找范围的左边界</param>
        /// <returns></returns>
        private IList<IList<int>> Sum(int[] sortedNums, int target, int sumLength, int index = 0)
        {
            // 每次递归都减少数字总量，当总量大于数组总长度时，结果自然为空的集合
            // 当数字总量等于2时，可以使用TwoSum函数，用双指针法，在O（n）时间复杂度下查找所有可能性，而不需要继续递归
            // 我自己的实现就没有这个部分，而是使用递归直至得到结果，有很多时间上的浪费
            if (sortedNums.Length < sumLength)
                return new List<IList<int>>();
            if (sumLength == 2)
                return TwoSum(sortedNums, target, index);

            IList<IList<int>> result = new List<IList<int>>();
            for (int i = index; i <= sortedNums.Length - sumLength; i++)
            {
                // 假设最终的集合中包含当前（位置i）的数字，以此为基础查找余下的区域
                IList<IList<int>> sumLengthMinusOneResults = Sum(sortedNums, target - sortedNums[i], sumLength - 1, i + 1);
                foreach (var list in sumLengthMinusOneResults)
                {
                    // 查找到了符合要求的集合，将当前数字添加到集合中，并且将添加完成的集合作为结果返回到上一层递归中
                    list.Insert(0, sortedNums[i]);
                    result.Add(list);
                }

                // 当添加完成后，移动查找范围的左边界，跳过所有的重复数字（数组已排序）
                // 因为之前的递归操作，其含义为“查找所有包含当前位置的数字组合”，这其中包含了所有的重复数字组合，所以下一轮循环的时候就不能再次计算
                // 否则最终结果就会包含重复结果
                while (i < sortedNums.Length - sumLength && sortedNums[i] == sortedNums[i + 1])
                    i++;
            }

            return result;
        }

        /// <summary>
        /// 某两个数之和等于给定数值，查找所有的可能集合
        /// </summary>
        /// <param name="sortedNums">排序数组</param>
        /// <param name="target">目标数值</param>
        /// <param name="index">查找范围的左边界位置</param>
        /// <returns></returns>
        private IList<IList<int>> TwoSum(int[] sortedNums, int target, int index = 0)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int left = index;
            int right = sortedNums.Length - 1;
            // 使用双指针法遍历所有的可能性组合
            while (left < right)
            {
                int sum = sortedNums[left] + sortedNums[right];
                if (sum > target)
                    right--;
                else if (sum < target)
                {
                    do
                        left++;
                    while (left > 0 && left < right && sortedNums[left] == sortedNums[left - 1]);
                }
                else
                {
                    result.Add(new List<int> { sortedNums[left], sortedNums[right] });
                    do
                        left++;
                    while (left > 0 && left < right && sortedNums[left] == sortedNums[left - 1]);
                }
            }

            return result;
        }
    }
}
