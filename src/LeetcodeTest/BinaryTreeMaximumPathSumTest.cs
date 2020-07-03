using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class BinaryTreeMaximumPathSumTest
    {
        [Fact]
        public void TestWithSingleNodeTree()
        {
            Assert.Equal(3, new BinaryTreeMaximumPathSum_124().MaxPathSum(new TreeNode(3)));
            Assert.Equal(0, new BinaryTreeMaximumPathSum_124().MaxPathSum(new TreeNode(0)));
            Assert.Equal(-1, new BinaryTreeMaximumPathSum_124().MaxPathSum(new TreeNode(-1)));

            Assert.Equal(int.MinValue,
                new BinaryTreeMaximumPathSum_124().MaxPathSum(new TreeNode(int.MinValue)));
            Assert.Equal(int.MaxValue,
                new BinaryTreeMaximumPathSum_124().MaxPathSum(new TreeNode(int.MaxValue)));
        }

        [Fact]
        public void TestWithNormalTree_TargetPathLimitedInLeftNode()
        {
            var target = new BinaryTreeMaximumPathSum_124();

            var tree = new TreeNode(-3)
            {
                left = new TreeNode(-1) // 路径限定在左子节点内部
                {
                    left = new TreeNode(20),
                    right = new TreeNode(-2)
                }
            };

            Assert.Equal(20, target.MaxPathSum(tree));
        }

        [Fact]
        public void TestWithNormalTree_TargetPathIncludeRootNode()
        {
            var target = new BinaryTreeMaximumPathSum_124();

            var tree = new TreeNode(-3)
            {
                left = new TreeNode(5) // 路径包括左子节点和根节点
                {
                    left = new TreeNode(20),
                    right = new TreeNode(-2)
                }
            };

            Assert.Equal(25, target.MaxPathSum(tree));
        }

        [Fact]
        public void TestWithNormalTree_TargetPathIncludeRootNodeAndParent()
        {
            var target = new BinaryTreeMaximumPathSum_124();

            var tree = new TreeNode(5)
            {
                left = new TreeNode(5) // 路径包括左子节点,根节点以及父节点
                {
                    left = new TreeNode(20),
                    right = new TreeNode(-2)
                },
                right = new TreeNode(-2)
            };

            Assert.Equal(30, target.MaxPathSum(tree));
        }

        [Fact]
        public void TestWithNormalTree_TargetPathIncludeLeftRootAndRight()
        {
            var target = new BinaryTreeMaximumPathSum_124();

            var tree = new TreeNode(5)
            {
                left = new TreeNode(5) // 路径包括左子节点,根节点以及右子节点
                {
                    left = new TreeNode(20),
                    right = new TreeNode(6)
                },
                right = new TreeNode(-2)
            };

            Assert.Equal(31, target.MaxPathSum(tree));
        }
    }
}
