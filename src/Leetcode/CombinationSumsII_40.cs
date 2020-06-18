using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class CombinationSumsII_40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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

        private void CombinationSumRecursively(int[] candidates, int currentIndex, int target,
            IList<IList<int>> resultList, List<int> singleResult)
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
                // 重复的数字都跳过，因为包含重复的情况都在递归中解决了，本循环中currentIndex下一个指向的如果还是相同的数字，则结果中可能有重复组合
                if (i > currentIndex && candidates[i] == candidates[i - 1])
                    continue;
                singleResult.Add(candidates[i]);
                // 这里给下一轮递归的参数是i+1，因为题目中不允许一个数字多次使用
                CombinationSumRecursively(candidates, i + 1, target - candidates[i], resultList, singleResult);
                singleResult.RemoveAt(singleResult.Count - 1);
            }
        }

        // 和#39一样，基准条件写复杂了，导致后面的循环也增加了许多复杂代码，这些都是没有必要的
        //private void CombinationSumRecursively(int[] candidates, int currentIndex, int target, IList<IList<int>> resultList, List<int> singleResult)
        //{
        //    if (currentIndex == candidates.Length || candidates[currentIndex] > target)
        //        return;

        //    int nextIndex = GetNextValueStartIndex(candidates, currentIndex);

        //    for (int i = currentIndex; i <= nextIndex; i++)
        //    {
        //        int allChosenCount = nextIndex - i;
        //        int allChosenSum = candidates[currentIndex] * allChosenCount;

        //        if (target > allChosenSum)
        //        {
        //            AddTimes(singleResult, candidates[currentIndex], allChosenCount);
        //            CombinationSumRecursively(candidates, nextIndex, target - allChosenSum, resultList, singleResult);
        //            singleResult.RemoveAll(o => o == candidates[currentIndex]);
        //        }
        //        else if (target == allChosenSum)
        //        {
        //            List<int> copy = singleResult.ToList();
        //            AddTimes(copy, candidates[currentIndex], allChosenCount);
        //            resultList.Add(copy);
        //        }
        //    }
        //}

        //private int GetNextValueStartIndex(int[] candidates, int currentIndex)
        //{
        //    int resultIndex = currentIndex;
        //    while (resultIndex < candidates.Length && candidates[resultIndex] == candidates[currentIndex])
        //        resultIndex++;
        //    return resultIndex;
        //}

        private void AddTimes(List<int> list, int item, int times)
        {
            for (int i = 1; i <= times; i++)
                list.Add(item);
        }
    }
}
