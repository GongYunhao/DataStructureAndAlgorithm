using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class DoesTreeAContainsTreeBTest
    {
        [Fact]
        public void NormalTest()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(20);
            root.Left = new BinaryTreeNode<int>(45);
            root.Right = new BinaryTreeNode<int>(66);

            BinaryTreeNode<int> treeB = new BinaryTreeNode<int>(45);
            Assert.True(DoesTreeAContainsTreeB.HasSubtree(root, treeB));

            treeB.Right = new BinaryTreeNode<int>(4);
            Assert.False(DoesTreeAContainsTreeB.HasSubtree(root, treeB));
        }
    }
}
