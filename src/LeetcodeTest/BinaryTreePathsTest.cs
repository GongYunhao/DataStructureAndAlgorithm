using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class BinaryTreePathsTest
    {
        [Fact]
        public void TestWithNullRoot()
        {
            Assert.Empty(new BinaryTreePaths_257().BinaryTreePaths(null));
        }

        [Fact]
        public void TestWithSingleNodeTree()
        {
            var algo = new BinaryTreePaths_257();

            var root = new TreeNode(10);

            var result = algo.BinaryTreePaths(root);

            Assert.Single(result);
            Assert.Equal("10", result[0]);
        }

        [Fact]
        public void TestWithNormalTree()
        {
            var algo = new BinaryTreePaths_257();

            var root = new TreeNode(10)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
            };

            var result = algo.BinaryTreePaths(root);

            Assert.Equal(2, result.Count);
            Assert.True(result.ContainsSameElement(new[] { "10->2->5", "10->3" }));
        }
    }
}
