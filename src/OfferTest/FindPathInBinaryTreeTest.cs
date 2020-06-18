using System;
using System.Collections.Generic;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class FindPathInBinaryTreeTest
    {
        [Fact]
        public void FullBinaryTreeWithOnlyOneRoute()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1);
            root.Left = new BinaryTreeNode<int>(2);
            root.Right = new BinaryTreeNode<int>(3);
            root.Left.Left = new BinaryTreeNode<int>(5);
            root.Left.Right = new BinaryTreeNode<int>(6);
            root.Right.Left = new BinaryTreeNode<int>(7);
            root.Right.Right = new BinaryTreeNode<int>(8);

            List<List<BinaryTreeNode<int>>> allRoutes = FindPathInBinaryTree.GetPath(root, 11);
            Assert.Single(allRoutes);
            Assert.Equal(3, allRoutes[0].Count);
            Assert.Equal(1, allRoutes[0][0].Value);
            Assert.Equal(3, allRoutes[0][1].Value);
            Assert.Equal(7, allRoutes[0][2].Value);

            allRoutes = FindPathInBinaryTree.GetPath(root, 12);
            Assert.Single(allRoutes);
            Assert.Equal(3, allRoutes[0].Count);
            Assert.Equal(1, allRoutes[0][0].Value);
            Assert.Equal(3, allRoutes[0][1].Value);
            Assert.Equal(8, allRoutes[0][2].Value);
        }

        [Fact]
        public void FullBinaryTreeWithMultipleRoutes()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1);
            root.Left = new BinaryTreeNode<int>(3);
            root.Right = new BinaryTreeNode<int>(2);
            root.Left.Left = new BinaryTreeNode<int>(5);
            root.Left.Right = new BinaryTreeNode<int>(7);
            root.Right.Left = new BinaryTreeNode<int>(6);
            root.Right.Right = new BinaryTreeNode<int>(8);

            List<List<BinaryTreeNode<int>>> allRoutes = FindPathInBinaryTree.GetPath(root, 11);
            Assert.Equal(2, allRoutes.Count);
            Assert.Equal(3, allRoutes[0].Count);
            Assert.Equal(1, allRoutes[0][0].Value);
            Assert.Equal(3, allRoutes[0][1].Value);
            Assert.Equal(7, allRoutes[0][2].Value);
            Assert.Equal(3, allRoutes[1].Count);
            Assert.Equal(1, allRoutes[1][0].Value);
            Assert.Equal(2, allRoutes[1][1].Value);
            Assert.Equal(8, allRoutes[1][2].Value);

            allRoutes = FindPathInBinaryTree.GetPath(root, 9);
            Assert.Equal(2, allRoutes.Count);
            Assert.Equal(3, allRoutes[0].Count);
            Assert.Equal(1, allRoutes[0][0].Value);
            Assert.Equal(3, allRoutes[0][1].Value);
            Assert.Equal(5, allRoutes[0][2].Value);
            Assert.Equal(3, allRoutes[1].Count);
            Assert.Equal(1, allRoutes[1][0].Value);
            Assert.Equal(2, allRoutes[1][1].Value);
            Assert.Equal(6, allRoutes[1][2].Value);

            allRoutes = FindPathInBinaryTree.GetPath(root, 5);
            Assert.Empty(allRoutes);
        }

        [Fact]
        public void NormalBinaryTreeWithMultipleRoutes()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);
            root.Left = new BinaryTreeNode<int>(5);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(4);
            root.Left.Right = new BinaryTreeNode<int>(7);

            List<List<BinaryTreeNode<int>>> allRoutes = FindPathInBinaryTree.GetPath(root, 22);
            Assert.Equal(2, allRoutes.Count);
            Assert.Equal(3, allRoutes[0].Count);
            Assert.Equal(10, allRoutes[0][0].Value);
            Assert.Equal(5, allRoutes[0][1].Value);
            Assert.Equal(7, allRoutes[0][2].Value);
            Assert.Equal(2, allRoutes[1].Count);
            Assert.Equal(10, allRoutes[1][0].Value);
            Assert.Equal(12, allRoutes[1][1].Value);
        }

        [Fact]
        public void BinaryTreeWithOnlyOneNode()
        {
            var allRoutes = FindPathInBinaryTree.GetPath(new BinaryTreeNode<int>(50), 50);
            Assert.Single(allRoutes);
            Assert.Single(allRoutes[0]);
            Assert.Equal(50, allRoutes[0][0].Value);

            allRoutes = FindPathInBinaryTree.GetPath(new BinaryTreeNode<int>(50), 60);
            Assert.Empty(allRoutes);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => FindPathInBinaryTree.GetPath(null, 20));
            Assert.Throws<ArgumentException>(() => FindPathInBinaryTree.GetPath(new BinaryTreeNode<int>(50), -2));
        }
    }
}
