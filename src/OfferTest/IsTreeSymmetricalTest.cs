using System;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class IsTreeSymmetricalTest
    {
        [Fact]
        public void UnsymmetricalFullBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Left.Right = new BinaryTreeNode<int>(45);
            root.Right.Left = new BinaryTreeNode<int>(112);
            root.Right.Right = new BinaryTreeNode<int>(111);

            Assert.False(IsTreeSymmetrical.IsSymmetrical(root));
        }

        [Fact]
        public void SymmetricalFullBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(65);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Left.Right = new BinaryTreeNode<int>(45);
            root.Right.Left = new BinaryTreeNode<int>(45);
            root.Right.Right = new BinaryTreeNode<int>(98);

            Assert.True(IsTreeSymmetrical.IsSymmetrical(root));
        }

        [Fact]
        public void FullBinaryTreeWithSymmetricalStructureButNotValue()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(65);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Left.Right = new BinaryTreeNode<int>(5);
            root.Right.Left = new BinaryTreeNode<int>(45);
            root.Right.Right = new BinaryTreeNode<int>(98);

            Assert.False(IsTreeSymmetrical.IsSymmetrical(root));
        }

        [Fact]
        public void FullBinaryTreeSameValue()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(7);
            root.Left = new BinaryTreeNode<int>(7);
            root.Right = new BinaryTreeNode<int>(7);
            root.Left.Left = new BinaryTreeNode<int>(7);
            root.Left.Right = new BinaryTreeNode<int>(7);
            root.Right.Left = new BinaryTreeNode<int>(7);
            root.Right.Right = new BinaryTreeNode<int>(7);

            Assert.True(IsTreeSymmetrical.IsSymmetrical(root));
        }

        [Fact]
        public void UnsymmetricalNormalBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Left.Right = new BinaryTreeNode<int>(45);
            root.Right.Right = new BinaryTreeNode<int>(111);
            Assert.False(IsTreeSymmetrical.IsSymmetrical(root));


            BinaryTreeNode<int> root1 = new BinaryTreeNode<int>(23);
            root1.Left = new BinaryTreeNode<int>(65);
            Assert.False(IsTreeSymmetrical.IsSymmetrical(root1));
        }

        [Fact]
        public void SymmetricalNormalBinaryTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(12);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Right.Right = new BinaryTreeNode<int>(98);

            Assert.True(IsTreeSymmetrical.IsSymmetrical(root));
        }

        [Fact]
        public void BinaryTreeWithOnlyOneNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);

            Assert.True(IsTreeSymmetrical.IsSymmetrical(root));
        }

        [Fact]
        public void InvalidInput()
        {
            BinaryTreeNode<int> root = null;
            Assert.Throws<ArgumentNullException>(() => IsTreeSymmetrical.IsSymmetrical(root));
        }
    }
}
