using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class CountCompleteTreeNodesTest
    {
        [Fact]
        public void TestWithNullRoot()
        {
            Assert.Equal(0, new CountCompleteTreeNodes_222().CountNodes(null));
        }

        [Fact]
        public void TestWithSingleRoot()
        {
            Assert.Equal(1, new CountCompleteTreeNodes_222().CountNodes(new TreeNode(1)));
        }

        [Fact]
        public void TestWithIncompleteTree_FinalLeafIsLeft()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6)
                }
            };

            Assert.Equal(6, new CountCompleteTreeNodes_222().CountNodes(root));
        }

        [Fact]
        public void TestWithIncompleteTree_FinalLeafIsRight()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {

                }
            };

            Assert.Equal(5, new CountCompleteTreeNodes_222().CountNodes(root));
        }

        [Fact]
        public void TestWithCompleteTree()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                }
            };

            Assert.Equal(7, new CountCompleteTreeNodes_222().CountNodes(root));
        }
    }
}
