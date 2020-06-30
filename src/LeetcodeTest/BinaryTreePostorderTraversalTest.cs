using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class BinaryTreePostorderTraversalTest
    {
        private const bool useRecursion = false;

        [Fact]
        public void TestWithNullRoot()
        {
            var target = BinaryTreePostorderTraversalFactory.GetConcrete(useRecursion);
            TreeNode tree = null;
            Assert.Empty(target.PostorderTraversal(tree));
        }

        [Fact]
        public void TestWithOneNodeTree()
        {
            var target = BinaryTreePostorderTraversalFactory.GetConcrete(useRecursion);
            var tree = new TreeNode(3);
            var result = target.PostorderTraversal(tree);

            Assert.Single(result);
            Assert.True(result.SameAs(new[] { 3 }));
        }

        [Fact]
        public void TestWithThreeLevelTree()
        {
            var target = BinaryTreePostorderTraversalFactory.GetConcrete(useRecursion);
            var tree = new TreeNode(3)
            {
                right = new TreeNode(5)
                {
                    left = new TreeNode(20)
                }
            };
            var result = target.PostorderTraversal(tree);

            Assert.Equal(3, result.Count);
            Assert.True(result.SameAs(new[] { 20, 5, 3 }));
        }

        [Fact]
        public void TestWithAllLeftChildTree()
        {
            var target = BinaryTreePostorderTraversalFactory.GetConcrete(useRecursion);
            var tree = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(20)
                }
            };
            var result = target.PostorderTraversal(tree);

            Assert.Equal(3, result.Count);
            Assert.True(result.SameAs(new[] { 20, 5, 3 }));
        }

        [Fact]
        public void TestWithThreeLevelFullTree()
        {
            var target = BinaryTreePostorderTraversalFactory.GetConcrete(useRecursion);
            var tree = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(20),
                    right = new TreeNode(30)
                },
                right = new TreeNode(25)
                {
                    left = new TreeNode(55),
                    right = new TreeNode(65)
                }
            };
            var result = target.PostorderTraversal(tree);

            Assert.Equal(7, result.Count);
            Assert.True(result.SameAs(new[] { 20, 30, 5, 55, 65, 25, 3 }));
        }
    }
}
