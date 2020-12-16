using CommonModels;
using System;

namespace Leetcode
{
    public class MinimumDepthOfBinaryTree_111
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
            {
                return 1;
            }
            else if (root.left == null && root.right != null)
            {
                return MinDepth(root.right) + 1;
            }
            else if (root.left != null && root.right == null)
            {
                return MinDepth(root.left) + 1;
            }
            else
            {
                return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
            }
        }
    }
}
