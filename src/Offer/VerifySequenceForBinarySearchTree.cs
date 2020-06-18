using System;

namespace Offer
{
    public class VerifySequenceForBinarySearchTree
    {
        public static bool Verify(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "The input array can't be null");
            if (array.Length == 0)
                return false;

            return VerifyRecursively(array, 0, array.Length - 1);
        }

        private static bool VerifyRecursively(int[] array, int startIndex, int endIndex)
        {
            int lastIndexOfLeftChildTree = startIndex - 1;
            bool isInRightChildTree = false;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (array[i] < array[endIndex])
                {
                    lastIndexOfLeftChildTree = i;

                    if (isInRightChildTree)
                        // 一旦越过了左右子树的分界点,进入到右子树的部分后,如果依然发现小于根节点的元素,则这个序列不可能是一个后序遍历序列
                        return false;
                }
                else
                {
                    isInRightChildTree = true;
                }
            }

            bool result = true;
            if (lastIndexOfLeftChildTree >= startIndex)
                result &= VerifyRecursively(array, startIndex, lastIndexOfLeftChildTree);
            if (lastIndexOfLeftChildTree < endIndex - 1)
                result &= VerifyRecursively(array, lastIndexOfLeftChildTree + 1, endIndex - 1);

            return result;// 只有左右子树同时为true,或者区域内只有一个根,不包含左右子树,总结果才能返回true
        }
    }
}
