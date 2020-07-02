using System;
using System.Diagnostics;
using CommonModels;

namespace Leetcode
{
    public class BinaryTreeMaximumPathSum_129
    {
        private int result = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxPathSumRecursively(root);

            return result;
        }

        private int MaxPathSumRecursively(TreeNode subTreeRoot)
        {
            int? left = subTreeRoot.left == null ? default : MaxPathSumRecursively(subTreeRoot.left);
            int? right = subTreeRoot.right == null ? default : MaxPathSumRecursively(subTreeRoot.right);

            ReplaceResultWithLarger(left);
            ReplaceResultWithLarger(right);

            if(HasAboveZeroValue(left) && HasAboveZeroValue(right))
            {
                ReplaceResultWithLarger(subTreeRoot.val + left.Value + right.Value);
            }

            if (HasAboveZeroValue(left) && HasAboveZeroValue(right))
            {
                var pathVal = subTreeRoot.val + left.Value > right.Value ? left.Value : right.Value;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
            else if (HasAboveZeroValue(right))
            {
                var pathVal = subTreeRoot.val + right.Value;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
            else if (HasAboveZeroValue(left))
            {
                var pathVal = subTreeRoot.val + left.Value;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
            else
            {
                var pathVal = subTreeRoot.val;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
        }

        private void ReplaceResultWithLarger(int? newVal)
        {
            if (!newVal.HasValue)
                return;

            if (newVal.Value > result)
                result = newVal.Value;
        }

        private bool HasAboveZeroValue(int? val)
        {
            return val.HasValue && val.Value > 0;
        }
    }
}
