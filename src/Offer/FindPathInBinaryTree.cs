using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels;

namespace Offer
{
    public class FindPathInBinaryTree
    {
        public static List<List<BinaryTreeNode<int>>> GetPath(BinaryTreeNode<int> root, int expectedSum)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The input binary tree can't be null");
            if (expectedSum < 0)
                throw new ArgumentException("The expected sum can't be under 0", nameof(expectedSum));

            List<List<BinaryTreeNode<int>>> allRoutes = new List<List<BinaryTreeNode<int>>>();
            FindRecursively(root, expectedSum, new List<BinaryTreeNode<int>>(), allRoutes);
            return allRoutes;
        }

        private static void FindRecursively(BinaryTreeNode<int> root, int expectedSum,
            List<BinaryTreeNode<int>> currentRoute, List<List<BinaryTreeNode<int>>> allRoutes)
        {
            if (root == null || root.Value > expectedSum)
                return;

            // 将当前节点加入到当前路径中,有点类似于回溯法寻找矩阵中路径的那一题,但是遍历二叉树只会从上到下,所以不需要额外标记
            currentRoute.Add(root);
            if (root.Value == expectedSum)
            {
                // 当前节点值恰好等于期望的值,将当前的路径复制一个副本出来,添加到所有路径的集合中
                allRoutes.Add(currentRoute.ToList());
            }
            else if (root.Value < expectedSum)
            {
                // 当前节点值小于期望,所以需要递归地去查看子节点
                FindRecursively(root.Left, expectedSum - root.Value, currentRoute, allRoutes);
                FindRecursively(root.Right, expectedSum - root.Value, currentRoute, allRoutes);
            }

            // 当前节点和子节点都遍历完成,需要返回到上一级继续遍历
            // 无论是否找到结果,都要将当前节点从路径中去除,这样其他节点就可以继续使用这个变量,而不需要分配新内存
            currentRoute.Remove(root);
        }
    }
}
