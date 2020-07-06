using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class BalancedBinaryTreeTest
    {
        [Fact]
        public void TestWithNullRoot()
        {
            Assert.True(new BalancedBinaryTree_110().IsBalanced(null));
        }

        [Fact]
        public void TestWithSingleNodeRoot()
        {
            var target = new BalancedBinaryTree_110();
            var tree = new TreeNode(30);
            Assert.True(target.IsBalanced(tree));
        }

        [Fact]
        public void TestWithTwoLevelTree_AlwaysBalanced()
        {
            var target = new BalancedBinaryTree_110();
            var tree = new TreeNode(30)
            {
                left = new TreeNode(10)
            };
            Assert.True(target.IsBalanced(tree));
        }

        [Fact]
        public void TestWithThreeLevelTree_Balanced()
        {
            var target = new BalancedBinaryTree_110();
            var tree = new TreeNode(30)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(1)
                },
                right = new TreeNode(45)
            };
            Assert.True(target.IsBalanced(tree));
        }

        [Fact]
        public void TestWithThreeLevelTree_Unbalanced()
        {
            var target = new BalancedBinaryTree_110();
            var tree = new TreeNode(30)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(1)
                }
            };
            Assert.False(target.IsBalanced(tree));
        }

        [Fact]
        public void TestWithTree_Balanced()
        {
            var target = new BalancedBinaryTree_110();
            var tree = new TreeNode(30)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(1)
                    {
                        right = new TreeNode(6)
                    },
                    right = new TreeNode(20)
                },
                right = new TreeNode(45)
                {
                    left = new TreeNode(33)
                }
            };
            Assert.True(target.IsBalanced(tree));
        }

        [Fact]
        public void TestWithTree_Unalanced()
        {
            var target = new BalancedBinaryTree_110();
            var tree = new TreeNode(30)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(6)
                    }
                }
            };
            Assert.False(target.IsBalanced(tree));
        }
    }
}
