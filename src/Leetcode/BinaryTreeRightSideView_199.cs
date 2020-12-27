using CommonModels;
using System.Collections.Generic;

namespace Leetcode
{
    public class BinaryTreeRightSideView_199
    {
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> result = new List<int>();
            RightSideView(root, 0, ref result);
            return result;
        }

        private void RightSideView(TreeNode subTreeRoot, int currentLevel, ref IList<int> result)
        {
            if (subTreeRoot == null)
                return;

            if (result.Count < currentLevel + 1)
            {
                result.Add(subTreeRoot.val);
            }

            RightSideView(subTreeRoot.right, currentLevel + 1, ref result);
            RightSideView(subTreeRoot.left, currentLevel + 1, ref result);
        }
    }
}
