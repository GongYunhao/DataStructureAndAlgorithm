using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class BinaryTreeRightSideViewTest
    {
        [Fact]
        public void TestNullRoot()
        {
            var algo = new BinaryTreeRightSideView_199();
            var list = algo.RightSideView(null);
            Assert.Empty(list);
        }

        [Fact]
        public void TestWithOneNodeTree()
        {
            var algo = new BinaryTreeRightSideView_199();
            var list = algo.RightSideView(new TreeNode(20));
            Assert.Single(list);
            Assert.Equal(20, list[0]);
        }

        [Fact]
        public void TestWithCommonTree1()
        {
            var algo = new BinaryTreeRightSideView_199();

            var tree = new TreeNode(3)
            {
                right = new TreeNode(5),
                left = new TreeNode(20)
            };

            var list = algo.RightSideView(tree);
            Assert.Equal(2, list.Count);
            Assert.Equal(3, list[0]);
            Assert.Equal(5, list[1]);
        }

        [Fact]
        public void TestWithCommonTree2()
        {
            var algo = new BinaryTreeRightSideView_199();

            var tree = new TreeNode(3)
            {
                right = new TreeNode(5)
                {
                    left = new TreeNode(23)
                },
                left = new TreeNode(20)
            };

            var list = algo.RightSideView(tree);
            Assert.Equal(3, list.Count);
            Assert.Equal(3, list[0]);
            Assert.Equal(5, list[1]);
            Assert.Equal(23, list[2]);
        }

        [Fact]
        public void TestWithCommonTree3()
        {
            var algo = new BinaryTreeRightSideView_199();

            var tree = new TreeNode(3)
            {
                right = new TreeNode(5),
                left = new TreeNode(20)
                {
                    left = new TreeNode(23)
                }
            };

            var list = algo.RightSideView(tree);
            Assert.Equal(3, list.Count);
            Assert.Equal(3, list[0]);
            Assert.Equal(5, list[1]);
            Assert.Equal(23, list[2]);
        }

        [Fact]
        public void TestWithOneSide1()
        {
            var algo = new BinaryTreeRightSideView_199();

            var tree = new TreeNode(3)
            {
                left = new TreeNode(20)
                {
                    left = new TreeNode(23)
                    {
                        left = new TreeNode(88)
                    }
                }
            };

            var list = algo.RightSideView(tree);
            Assert.Equal(4, list.Count);
            Assert.Equal(3, list[0]);
            Assert.Equal(20, list[1]);
            Assert.Equal(23, list[2]);
            Assert.Equal(88, list[3]);
        }

        [Fact]
        public void TestWithOneSide2()
        {
            var algo = new BinaryTreeRightSideView_199();

            var tree = new TreeNode(3)
            {
                right = new TreeNode(20)
                {
                    right = new TreeNode(23)
                    {
                        right = new TreeNode(88)
                    }
                }
            };

            var list = algo.RightSideView(tree);
            Assert.Equal(4, list.Count);
            Assert.Equal(3, list[0]);
            Assert.Equal(20, list[1]);
            Assert.Equal(23, list[2]);
            Assert.Equal(88, list[3]);
        }
    }
}
