using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class RecoverBinarySearchTreeTest
    {
        [Fact]
        public void ExchangeHeadAndTail()
        {
            var root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(25),
                    right = new TreeNode(7)
                },
                right = new TreeNode(20)
                {
                    left = new TreeNode(16),
                    right = new TreeNode(1)
                }
            };

            var algo = new RecoverBinarySearchTree_99();
            algo.RecoverTree(root);

            Assert.Equal(1, root.left.left.val);
            Assert.Equal(25, root.right.right.val);
        }

        [Fact]
        public void ExchangeNormal()
        {
            var root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(16)
                },
                right = new TreeNode(20)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(25)
                }
            };

            var algo = new RecoverBinarySearchTree_99();
            algo.RecoverTree(root);

            Assert.Equal(7, root.left.right.val);
            Assert.Equal(16, root.right.left.val);
        }

        [Fact]
        public void ExchangeNeighbour()
        {
            var root = new TreeNode(7)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(10)
                },
                right = new TreeNode(20)
                {
                    left = new TreeNode(16),
                    right = new TreeNode(25)
                }
            };

            var algo = new RecoverBinarySearchTree_99();
            algo.RecoverTree(root);

            Assert.Equal(10, root.val);
            Assert.Equal(7, root.left.right.val);
        }
    }
}
