using CommonModels;

namespace Leetcode
{
    public class InvertBinaryTree_226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                var left = InvertTree(root.left);
                var right = InvertTree(root.right);

                root.left = right;
                root.right = left;
            }

            return root;
        }
    }
}
