using System;
using CommonModels;

namespace Leetcode
{
    public class ConstructBinaryTreefromInorderandPostorderTraversal_106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null || inorder.Length != postorder.Length)
                return null;

            return BuildSubTree(inorder, new SubTreeSpan(0, inorder.Length - 1), postorder, new SubTreeSpan(0, postorder.Length - 1));
        }

        private TreeNode BuildSubTree(int[] inorder, SubTreeSpan inorderSpan,
            int[] postorder, SubTreeSpan postorderSpan)
        {
            if (inorderSpan.StartIndex == inorderSpan.EndIndex)
            {
                if (inorder[inorderSpan.StartIndex] == postorder[postorderSpan.EndIndex])
                {
                    return new TreeNode(inorder[inorderSpan.StartIndex]);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else if (inorderSpan.StartIndex > inorderSpan.EndIndex)
            {
                return null;
            }

            var rootVal = postorder[postorderSpan.EndIndex];
            var rootNode = new TreeNode(rootVal);

            var subtreeDivider = FindInorderIndexByValue(inorder, inorderSpan, rootVal);
            rootNode.left = BuildSubTree(
                inorder,
                new SubTreeSpan(inorderSpan.StartIndex, subtreeDivider - 1),
                postorder,
                new SubTreeSpan(postorderSpan.StartIndex, postorderSpan.StartIndex + subtreeDivider - inorderSpan.StartIndex - 1));
            rootNode.right = BuildSubTree(
                inorder,
                new SubTreeSpan(subtreeDivider + 1, inorderSpan.EndIndex),
                postorder,
                new SubTreeSpan(postorderSpan.StartIndex + subtreeDivider - inorderSpan.StartIndex, postorderSpan.EndIndex - 1));

            return rootNode;
        }

        private int FindInorderIndexByValue(int[] inorder, SubTreeSpan inorderSpan, int targetVal)
        {
            for (int i = inorderSpan.StartIndex; i <= inorderSpan.EndIndex; i++)
            {
                if (inorder[i] == targetVal)
                {
                    return i;
                }
            }

            throw new ArgumentException($"Can not find target value in given inorder span. Target value is {targetVal}", nameof(targetVal));
        }

        private struct SubTreeSpan
        {
            internal SubTreeSpan(int startIndex, int endIndex)
            {
                StartIndex = startIndex;
                EndIndex = endIndex;
            }

            internal int StartIndex { get; set; }
            internal int EndIndex { get; set; }
        }
    }
}
