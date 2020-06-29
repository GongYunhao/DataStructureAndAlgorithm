using System.Collections.Generic;
using CommonModels;

namespace Leetcode
{
    public abstract class Binary_Tree_Preorder_Traversal_144
    {
        public abstract IList<int> PreorderTraversal(TreeNode root);
    }

    public class BinaryTreePreorderTraversalFactory
    {
        public static Binary_Tree_Preorder_Traversal_144 GetConcrete(bool useRecursion)
        {
            if (useRecursion)
                return new BinaryTreePreorderTraversal_WithRecursion();
            else
                return new BinaryTreePreorderTraversal_WithStack();
        }
    }

    public class BinaryTreePreorderTraversal_WithRecursion : Binary_Tree_Preorder_Traversal_144
    {
        public override IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();

            TraverseChildTree(root, result);

            return result;
        }

        private void TraverseChildTree(TreeNode root, IList<int> result)
        {
            if (root == null)
            {
                return;
            }

            result.Add(root.val);

            TraverseChildTree(root.left, result);
            TraverseChildTree(root.right, result);
        }
    }

    public class BinaryTreePreorderTraversal_WithStack : Binary_Tree_Preorder_Traversal_144
    {
        public override IList<int> PreorderTraversal(TreeNode root)
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

                if (currNode.right != null)
                {
                    stack.Push(currNode.right);
                }
                if (currNode.left != null)
                {
                    stack.Push(currNode.left);
                }
            }

            return result;
        }
    }
}
