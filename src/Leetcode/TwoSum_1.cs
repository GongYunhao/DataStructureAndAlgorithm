using System.Collections.Generic;

namespace Leetcode
{
    public class TwoSum_1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    return new[] { dic[nums[i]], i };
                }
                else
                {
                    if (!dic.ContainsKey(target - nums[i]))// 防止重复数字
                        dic.Add(target - nums[i], i);
                }
            }

            return new[] { 0, 0 };
        }
    }
}
