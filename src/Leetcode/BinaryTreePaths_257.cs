using System.Collections.Generic;
using CommonModels;

namespace Leetcode
{
    public class BinaryTreePaths_257
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();

            if (root == null)
                return result;

            BinaryTreePathRecursion(root, string.Empty, result);
            return result;
        }

        private void BinaryTreePathRecursion(TreeNode subTreeRoot, string currentStr, IList<string> result)
        {
            currentStr += subTreeRoot.val;

            if (subTreeRoot.left == null && subTreeRoot.right == null)
            {
                result.Add(currentStr);
                return;
            }

            currentStr += "->";

            if (subTreeRoot.left != null)
            {
                BinaryTreePathRecursion(subTreeRoot.left, currentStr, result);
            }
            if (subTreeRoot.right != null)
            {
                BinaryTreePathRecursion(subTreeRoot.right, currentStr, result);
            }
        }
    }
}
