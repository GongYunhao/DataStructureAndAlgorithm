using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class ConstructBinaryTreefromInorderandPostorderTraversalTest
    {
        [Fact]
        public void TestWithInvalidInput()
        {
            var target = new ConstructBinaryTreefromInorderandPostorderTraversal_106();
            Assert.Null(target.BuildTree(null, new[] { 9, 15, 7, 20, 3 }));
            Assert.Null(target.BuildTree(new[] { 9, 3, 15, 20 }, new[] { 9, 15, 7, 20, 3 }));

            Assert.Throws<ArgumentException>(() => target.BuildTree(new[] { 9, 3, 15, 20, 16 }, new[] { 9, 15, 7, 20, 3 }));
            Assert.Throws<ArgumentException>(() => target.BuildTree(new[] { 9, 3, 15, 18, 7 }, new[] { 9, 15, 7, 20, 3 }));
        }

        [Fact]
        public void TestWithSample()
        {
            var target = new ConstructBinaryTreefromInorderandPostorderTraversal_106();
            var root = target.BuildTree(new[] { 9, 3, 15, 20, 7 }, new[] { 9, 15, 7, 20, 3 });

            Assert.Equal(3, root.val);

            Assert.Equal(9, root.left.val);
            Assert.True(root.left.IsLeaf);

            Assert.Equal(20, root.right.val);

            Assert.Equal(15, root.right.left.val);
            Assert.True(root.right.left.IsLeaf);

            Assert.Equal(7, root.right.right.val);
            Assert.True(root.right.right.IsLeaf);
        }

        [Fact]
        public void TestWithSample2()
        {
            var target = new ConstructBinaryTreefromInorderandPostorderTraversal_106();
            var root = target.BuildTree(new[] { 4, 9, 3, 15, 20, 7 }, new[] { 4, 9, 15, 7, 20, 3 });

            Assert.Equal(3, root.val);

            Assert.Equal(9, root.left.val);

            Assert.Equal(4, root.left.left.val);
            Assert.True(root.left.left.IsLeaf);

            Assert.Equal(20, root.right.val);

            Assert.Equal(15, root.right.left.val);
            Assert.True(root.right.left.IsLeaf);

            Assert.Equal(7, root.right.right.val);
            Assert.True(root.right.right.IsLeaf);
        }
    }
}
