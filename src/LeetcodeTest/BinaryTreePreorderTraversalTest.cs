using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class BinaryTreePreorderTraversalTest
    {
        private const bool USE_RECURSION = false;

        [Fact]
        public void TestWithNullRoot()
        {
            var t = BinaryTreePreorderTraversalFactory.GetConcrete(USE_RECURSION);

            var result = t.PreorderTraversal(null);

            Assert.Empty(result);
        }

        [Fact]
        public void TestWithSingleNode()
        {
            var t = BinaryTreePreorderTraversalFactory.GetConcrete(USE_RECURSION);

            var result = t.PreorderTraversal(new TreeNode(5));

            Assert.Single(result);
            Assert.Equal(5, result[0]);
        }

        [Fact]
        public void TestWithNormalTree()
        {
            var tree = new TreeNode(20)
            {
                right = new TreeNode(25)
                {
                    left = new TreeNode(21)
                }
            };

            var t = BinaryTreePreorderTraversalFactory.GetConcrete(USE_RECURSION);

            var result = t.PreorderTraversal(tree);

            Assert.Equal(3, result.Count);
            Assert.True(result.ContainsSameElement(new[] { 20, 25, 21 }));
        }

        [Fact]
        public void TestWithAllLeftNode()
        {
            var tree = new TreeNode(20)
            {
                left = new TreeNode(15)
                {
                    left = new TreeNode(12)
                    {
                        left = new TreeNode(7)
                    }
                }
            };

            var t = BinaryTreePreorderTraversalFactory.GetConcrete(USE_RECURSION);

            var result = t.PreorderTraversal(tree);

            Assert.Equal(4, result.Count);
            Assert.True(result.ContainsSameElement(new[] { 20, 15, 12, 7 }));
        }

        [Fact]
        public void TestWithFullTree()
        {
            var tree = new TreeNode(20)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(13)
                },
                right = new TreeNode(36)
                {
                    left = new TreeNode(30),
                    right = new TreeNode(37)
                }
            };

            var t = BinaryTreePreorderTraversalFactory.GetConcrete(USE_RECURSION);

            var result = t.PreorderTraversal(tree);

            Assert.Equal(7, result.Count);
            Assert.True(result.ContainsSameElement(new[] { 20, 10, 5, 13, 36, 30, 37 }));
        }
    }
}
