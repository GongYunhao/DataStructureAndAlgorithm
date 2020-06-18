using System;
using CommonModels;

namespace Offer
{
    public class ConvertBinaryTreeToLinkedList
    {
        public static BinaryTreeNode<int> GetHead(BinaryTreeNode<int> root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The input binary tree can't be null");

            (BinaryTreeNode<int> min, _) = GetMinAndMaxRecursively(root);
            return min;
        }

        private static (BinaryTreeNode<int> min, BinaryTreeNode<int> max) GetMinAndMaxRecursively(BinaryTreeNode<int> root)
        {
            // 分别对应左右子树转换的最小和最大值
            // 设置初始值是为了应对当前节点为叶节点的情况(左右节点都是null,应当返回本节点,即root)
            BinaryTreeNode<int> leftMin = root, rightMax = root;
            if (root.Left != null)
            {
                BinaryTreeNode<int> leftMax;
                (leftMin, leftMax) = GetMinAndMaxRecursively(root.Left);
                leftMax.Right = root;// 链接左子树中最靠右的节点和当前轮的根节点,需要双向链接
                root.Left = leftMax;
            }

            if (root.Right != null)
            {
                BinaryTreeNode<int> rightMin;
                (rightMin, rightMax) = GetMinAndMaxRecursively(root.Right);
                rightMin.Left = root;
                root.Right = rightMin;
            }

            // 如果需要验证是否二叉搜索树,可以在此处检查,若leftMax>=root或者rightMin<=root,则这不是一个二叉搜索树,抛出异常
            return (leftMin, rightMax);
        }
    }
}
