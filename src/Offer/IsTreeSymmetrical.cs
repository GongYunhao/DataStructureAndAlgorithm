using System;
using CommonModels;

namespace Offer
{
    public class IsTreeSymmetrical
    {
        public static bool IsSymmetrical(BinaryTreeNode<int> root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The root of tree can't be null");

            return IsSymmetricalRecursively(root.Left, root.Right);
        }

        // 判断以left和right两个节点为根的子树是否对称
        private static bool IsSymmetricalRecursively(BinaryTreeNode<int> left, BinaryTreeNode<int> right)
        {
            // 共有四种情况:
            // left=null,right=null:两者都是空节点,对称
            // left=null,right!=null或者left!=null,right=null:根节点就不一致,无需进一步比对
            // left!=null,right!=null:又要细分两种情况,第一种是根节点值不一致,也无需比对;当根一致时,才需要比对子节点是否对称
            if (left == null)
                return right == null;
            if (right == null)
                return false;

            if (left.Value != right.Value)
                return false;

            // 比对子节点是否对称
            return IsSymmetricalRecursively(left.Left, right.Right) &&
                   IsSymmetricalRecursively(left.Right, right.Left);
        }
    }
}
