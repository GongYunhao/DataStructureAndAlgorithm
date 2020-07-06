using CommonModels;

namespace Leetcode
{
    public class BalancedBinaryTree_110
    {
        public bool IsBalanced(TreeNode root)
        {
            bool result;
            (result, _) = GetSubTreeHeight(root);
            return result;
        }

        private (bool, int) GetSubTreeHeight(TreeNode subTreeRoot)
        {
            if (subTreeRoot == null)
                return (true, 0);

            int leftHeight = 0, rightHeight = 0;
            if (subTreeRoot.left != null)
            {
                bool leftBalanced;
                (leftBalanced, leftHeight) = GetSubTreeHeight(subTreeRoot.left);
                if (!leftBalanced)
                {
                    return (false, 0);// if left subtree is unbalanced, whole tree is unbalanced, so we can take a shortcut here, no need to visit right subtree
                }
            }
            if (subTreeRoot.right != null)
            {
                bool rightBalanced;
                (rightBalanced, rightHeight) = GetSubTreeHeight(subTreeRoot.right);
                if (!rightBalanced)
                {
                    return (false, 0);
                }
            }

            // both left and right subtrees are balanced
            // check if root node balanced
            int bigger = leftHeight > rightHeight ? leftHeight : rightHeight;
            int smaller = leftHeight > rightHeight ? rightHeight : leftHeight;

            return (bigger - smaller <= 1, bigger + 1);
        }
    }
}
