using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class MirrorOfBinaryTreeTest
    {
        [Fact]
        public void NormalTest()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Right = new BinaryTreeNode<int>(12);
            root.Left.Left = new BinaryTreeNode<int>(98);
            root.Left.Right = new BinaryTreeNode<int>(45);
            root.Right.Right = new BinaryTreeNode<int>(111);

            MirrorOfBinaryTree.GetMirror(root);

            Assert.Equal(23, root.Value);
            Assert.Equal(12, root.Left.Value);
            Assert.Equal(111, root.Left.Left.Value);
            Assert.Equal(65, root.Right.Value);
            Assert.Equal(98, root.Right.Right.Value);
            Assert.Equal(45, root.Right.Left.Value);
        }

        [Fact]
        public void TreeWithOnlyLeftNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            root.Left = new BinaryTreeNode<int>(65);
            root.Left.Left = new BinaryTreeNode<int>(12);
            root.Left.Left.Left = new BinaryTreeNode<int>(120);

            MirrorOfBinaryTree.GetMirror(root);

            Assert.Equal(23, root.Value);
            Assert.Equal(65, root.Right.Value);
            Assert.Equal(12, root.Right.Right.Value);
            Assert.Equal(120, root.Right.Right.Right.Value);
        }

        [Fact]
        public void TreeWithOnlyOneNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(23);
            MirrorOfBinaryTree.GetMirror(root);
            Assert.Equal(23, root.Value);
        }

        [Fact]
        public void InvalidInput()
        {
            BinaryTreeNode<int> root = null;
            MirrorOfBinaryTree.GetMirror(root);
            Assert.Null(root);
        }
    }
}
