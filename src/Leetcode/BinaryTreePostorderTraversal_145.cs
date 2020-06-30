using System.Collections.Generic;
using CommonModels;

namespace Leetcode
{
    public abstract class BinaryTreePostorderTraversal_145
    {
        public abstract IList<int> PostorderTraversal(TreeNode root);
    }

    public class BinaryTreePostorderTraversalFactory
    {
        public static BinaryTreePostorderTraversal_145 GetConcrete(bool useRecursion)
        {
            if (useRecursion)
                return new Recursion();
            else
                return new Iteration();
        }
    }

    class Recursion : BinaryTreePostorderTraversal_145
    {
        public override IList<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            PostorderTraversalRecursively(root, result);
            return result;
        }

        private void PostorderTraversalRecursively(TreeNode subTreeRoot, IList<int> result)
        {
            if (subTreeRoot == null)
                return;

            PostorderTraversalRecursively(subTreeRoot.left, result);
            PostorderTraversalRecursively(subTreeRoot.right, result);
            result.Add(subTreeRoot.val);
        }
    }

    class Iteration : BinaryTreePostorderTraversal_145
    {
        public override IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new int[0];
            }

            var stack = new Stack<TreeNode>(1);
            stack.Push(root);

            var result = new List<int>();

            while (stack.Count > 0)
            {
                var currNode = stack.Pop();
                result.Add(currNode.val);

                if (currNode.left != null)
                {
                    stack.Push(currNode.left);
                }
                if (currNode.right != null)
                {
                    stack.Push(currNode.right);
                }
            }

            result.Reverse();

            return result;
        }
    }
}
