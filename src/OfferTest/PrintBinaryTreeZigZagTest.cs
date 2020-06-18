using System;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class PrintBinaryTreeZigZagTest
    {
        [Fact]
        public void FullBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Left.Right = new BinaryTreeNode<int>(45);
            root.Right.Left = new BinaryTreeNode<int>(112);
            root.Right.Right = new BinaryTreeNode<int>(111);

            Assert.Equal("23,12,65,98,45,112,111", PrintBinaryTreeZigZag.Print(root));
        }

        [Fact]
        public void NormalBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Right.Left = new BinaryTreeNode<int>(112);
            root.Right.Right = new BinaryTreeNode<int>(111);
            root.Right.Right.Right = new BinaryTreeNode<int>(236);
            root.Right.Right.Left = new BinaryTreeNode<int>(239);

            Assert.Equal("23,12,65,98,112,111,236,239", PrintBinaryTreeZigZag.Print(root));
        }

        [Fact]
        public void BinaryTreeThatContainsOnlyOneNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);

            Assert.Equal("23", PrintBinaryTreeZigZag.Print(root));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => PrintBinaryTreeZigZag.Print(null));
        }
    }
}
