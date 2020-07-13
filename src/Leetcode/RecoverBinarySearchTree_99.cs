using System.Collections.Generic;
using CommonModels;

namespace Leetcode
{
    public class RecoverBinarySearchTree_99
    {
        public void RecoverTree(TreeNode root)
        {
            if (root == null
                || (root.left == null && root.right == null))
                return;

            List<TreeNode> traversalResult = new List<TreeNode>();
            InOrderTraversal(root, traversalResult);

            TreeNode firstMistake = null, secondMistake = null;
            for (int i = 0; i <= traversalResult.Count - 2; i++)
            {
                var currNode = traversalResult[i];
                var postNode = traversalResult[i + 1];

                if (currNode.val > postNode.val)
                {
                    firstMistake = currNode;
                    break;
                }
            }

            for (int i = traversalResult.Count - 1; i >= 1; i--)
            {
                var currNode = traversalResult[i];
                var preNode = traversalResult[i - 1];

                if (currNode.val < preNode.val)
                {
                    secondMistake = currNode;
                    break;
                }
            }

            var firstMistakeVal = firstMistake.val;
            firstMistake.val = secondMistake.val;
            secondMistake.val = firstMistakeVal;
        }

        private void InOrderTraversal(TreeNode root, List<TreeNode> traversalResult)
        {
            if (root == null)
                return;

            InOrderTraversal(root.left, traversalResult);
            traversalResult.Add(root);
            InOrderTraversal(root.right, traversalResult);
        }
    }
}
