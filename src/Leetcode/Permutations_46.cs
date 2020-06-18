using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class Permutations_46
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();
            if (nums.Length == 0)
                return new List<IList<int>>();

            List<IList<int>> result = new List<IList<int>>();
            PermuteRecursively(nums, 0, result);
            return result;
        }

        private void PermuteRecursively(int[] nums, int startIndex, IList<IList<int>> resultList)
        {
            // 当startIndex到达数组末尾的时候，已经没有元素可以调换，递归到达终点
            // 将数组的一个副本添加到结果列表中（必须是副本，因为数组本身在后续过程中还会修改）
            if (startIndex == nums.Length - 1)
            {
                resultList.Add(new List<int>(nums));
                return;
            }

            // 针对leetcode#47增加一个hashset，如果元素已经调换过，需要添加到这个集合中
            // 这样下一次遍历到相同元素时，可以跳过，以此来避免生成重复的结果组合
            HashSet<int> set = new HashSet<int>();

            // 从当前轮的其实位置开始，向后遍历直到数组结束，每次遍历都将开始位置的元素和当前循环到的元素对调
            // 完成对调后，startIndex对应的元素就固定下来，接下来用递归方式去循环剩余数组
            // 当递归完成后，回到本轮函数，本轮函数将数组位置调换回来，便于下一轮循环中和其他元素调换顺序
            for (int i = startIndex; i <= nums.Length - 1; i++)
            {
                if (set.Contains(nums[i]))
                    continue;

                Swap(ref nums[startIndex], ref nums[i]);
                PermuteRecursively(nums, startIndex + 1, resultList);
                Swap(ref nums[startIndex], ref nums[i]);
                set.Add(nums[i]);
            }
        }

        private void Swap(ref int a, ref int b)
        {
            // 实际这种写法比下面的异或写法快一点
            int tmp = a;
            a = b;
            b = tmp;

            //if (a == b)
            //    return;

            //a = a ^ b;
            //b = a ^ b;
            //a = a ^ b;
        }
    }
}
