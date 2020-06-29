using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class SumRootToLeafNumbersTest
    {
        [Fact]
        public void TestWithNullRoot()
        {
            var target = new SumRootToLeafNumbers_129();
            Assert.Equal(0, target.SumNumbers(null));
        }

        [Fact]
        public void TestWithSingleNodeTree()
        {
            var target = new SumRootToLeafNumbers_129();

            var tree = new TreeNode(9);

            Assert.Equal(9, target.SumNumbers(tree));
        }

        [Fact]
        public void TestWithOneLevelDepthChildren()
        {
            var target = new SumRootToLeafNumbers_129();

            var tree1 = new TreeNode(9)
            {
                left = new TreeNode(5)
            };

            Assert.Equal(95, target.SumNumbers(tree1));

            var tree2 = new TreeNode(9)
            {
                right = new TreeNode(5)
            };

            Assert.Equal(95, target.SumNumbers(tree2));

            var tree3 = new TreeNode(9)
            {
                left = new TreeNode(5),
                right = new TreeNode(5)
            };

            Assert.Equal(190, target.SumNumbers(tree3));
        }

        [Fact]
        public void TestWithOnlyLeftChildren()
        {
            var target = new SumRootToLeafNumbers_129();

            var tree1 = new TreeNode(9)
            {
                left = new TreeNode(5)
                {
                    left  = new TreeNode(5)
                    {
                        left = new TreeNode(5)
                    }
                }
            };

            Assert.Equal(9555, target.SumNumbers(tree1));
        }

        [Fact]
        public void TestWithUnbalancedTree()
        {
            var target = new SumRootToLeafNumbers_129();

            var tree1 = new TreeNode(9)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(5)
                    {
                        left = new TreeNode(5)
                    }
                },
                right= new TreeNode(1)
            };

            Assert.Equal(9646, target.SumNumbers(tree1));
        }
    }
}
