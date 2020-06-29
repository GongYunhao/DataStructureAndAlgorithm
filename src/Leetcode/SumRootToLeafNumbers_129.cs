using CommonModels;

namespace Leetcode
{
    public class SumRootToLeafNumbers_129
    {
        public int SumNumbers(TreeNode root)
        {
            int total = 0;
            SumNumbersRecursively(root, 0,ref total);
            return total;
        }

        private void SumNumbersRecursively(TreeNode subTreeRoot,int baseValue,ref int total)
        {
            if (subTreeRoot == null)
                return;

            baseValue += subTreeRoot.val;

            if (subTreeRoot.left == null && subTreeRoot.right == null)
            {
                total += baseValue;
                return;
            }

            SumNumbersRecursively(subTreeRoot.left, baseValue * 10, ref total);
            SumNumbersRecursively(subTreeRoot.right, baseValue * 10, ref total);
        }
    }
}
