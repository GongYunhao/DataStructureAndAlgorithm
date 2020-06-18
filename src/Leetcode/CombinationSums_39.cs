using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class CombinationSums_39
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates == null)
                throw new ArgumentNullException(nameof(candidates), "The input array can't be null");
            if (target <= 0)
                throw new ArgumentException("The given target value can't be under zero", nameof(target));

            Array.Sort(candidates);
            IList<IList<int>> resultList = new List<IList<int>>();
            List<int> singleResult = new List<int>();
            CombinationSumRecursively(candidates, 0, target, resultList, singleResult);
            return resultList;
        }

        private void CombinationSumRecursively(int[] candidates, int currentIndex, int target, IList<IList<int>> resultList, List<int> singleResult)
        {
            if (target == 0)
            {
                resultList.Add(singleResult.ToList());
                return;
            }

            if (target < 0)
                return;

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                singleResult.Add(candidates[i]);
                // 这里给下一轮递归的参数是i，因为题目中允许一个数字多次使用
                CombinationSumRecursively(candidates, i, target - candidates[i], resultList, singleResult);
                singleResult.Remove(candidates[i]);
            }

            // 横线以下为原始解法，使用candidate[currentIndex]和target的关系作为基准条件
            // while循环中也加上了这些条件，导致代码更加复杂
            // 以后递归等基准情况和退出条件需要着重考虑，不能形成路径依赖
            ////------------------------------------------------------------------------------------------------------
            //if (candidates[currentIndex] > target)
            //    return;

            //// 每一轮递归要从上一轮的递归位置开始
            //// 这样一来，两轮可以选择同样的数组元素，但是下一轮不能选取到上一轮递归位置左侧的元素
            //// 比如从2，3中选取总和为7，那么只能按照2，2，3的路径去选择，而不能选择2，3，2之类的
            //// 更深层的递归，比如说上一轮已经选取了3，则下一轮递归就只能从3开始向右遍历，而不能选取左边的2
            //// 这样限制遍历起始位置后，最终结果中就不会有重复的项目
            //int index = currentIndex;

            //while (index <= candidates.Length - 1 && candidates[index] <= target)
            //{
            //    if (candidates[index] < target)
            //    {
            //        singleResult.Add(candidates[index]);
            //        CombinationSumRecursively(candidates, index, target - candidates[index], resultList, singleResult);
            //        singleResult.Remove(candidates[index]);
            //    }
            //    else
            //    {
            //        List<int> copy = singleResult.ToList();
            //        copy.Add(candidates[index]);
            //        resultList.Add(copy);
            //    }

            //    index++;
            //}
        }
    }
}
