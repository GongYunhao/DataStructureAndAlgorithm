using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class SameTreeTest
    {
        [Fact]
        public void TestWithNullRootTree()
        {
            var target = new SameTree_100();
            Assert.True(target.IsSameTree(null, null));

            var q = new TreeNode(5);
            Assert.False(target.IsSameTree(q, null));
            Assert.False(target.IsSameTree(null, q));
        }

        [Fact]
        public void TestWithSingleNodeTree()
        {
            var target = new SameTree_100();
            Assert.True(target.IsSameTree(new TreeNode(5), new TreeNode(5)));
            Assert.False(target.IsSameTree(new TreeNode(5), new TreeNode(10)));
        }

        [Fact]
        public void TestWithNormalTree_SameShape()
        {
            var target = new SameTree_100();
            var p = new TreeNode(5)
            {
                left = new TreeNode(3),
                right = new TreeNode(7)
            };
            var q = new TreeNode(5)
            {
                left = new TreeNode(3),
                right = new TreeNode(7)
            };
            var q1 = new TreeNode(5)
            {
                left = new TreeNode(7),
                right = new TreeNode(3)
            };


            Assert.True(target.IsSameTree(p, q));
            Assert.False(target.IsSameTree(p, q1));
        }

        [Fact]
        public void TestWithNormalTree_DiffShape()
        {
            var target = new SameTree_100();
            var p = new TreeNode(5)
            {
                left = new TreeNode(3),
                right = new TreeNode(7)
            };
            var q = new TreeNode(5)
            {
                left = new TreeNode(3)
            };

            Assert.False(target.IsSameTree(p, q));
        }
    }
}
