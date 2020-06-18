using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class RebuildBinaryTreeTest
    {
        [Fact]
        public void TestNormalExample()
        {
            int[] preorder = { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] inorder = { 4, 7, 2, 1, 5, 3, 8, 6 };

            // 验证重建的树结构是否与原始树一致
            BinaryTreeNode<int> root = RebuildBinaryTree.Execute(preorder, inorder);
            Assert.True(root.Value == 1);

            // 2
            Assert.True(root.Left.Value == 2);
            Assert.Null(root.Left.Right);

            // 4
            Assert.True(root.Left.Left.Value == 4);
            Assert.Null(root.Left.Left.Left);

            // 7
            Assert.True(root.Left.Left.Right.Value == 7);
            Assert.Null(root.Left.Left.Right.Left);
            Assert.Null(root.Left.Left.Right.Right);

            // 3
            Assert.True(root.Right.Value == 3);

            // 5
            Assert.True(root.Right.Left.Value == 5);
            Assert.Null(root.Right.Left.Left);
            Assert.Null(root.Right.Left.Right);

            // 6
            Assert.True(root.Right.Right.Value == 6);
            Assert.Null(root.Right.Right.Right);

            // 8
            Assert.True(root.Right.Right.Left.Value == 8);
            Assert.Null(root.Right.Right.Left.Right);
            Assert.Null(root.Right.Right.Left.Left);
        }

        [Fact]
        public void TestWrongInput()
        {
            int[] preorder = null, inorder = null;
            Assert.Throws<ArgumentException>(() => RebuildBinaryTree.Execute(preorder, inorder));

            int[] preorder1 = { 1 }, inorder1 = null;
            Assert.Throws<ArgumentException>(() => RebuildBinaryTree.Execute(preorder1, inorder1));

            int[] preorder2 = { 1 }, inorder2 = { 1, 2 };
            Assert.Throws<ArgumentException>(() => RebuildBinaryTree.Execute(preorder2, inorder2));

            int[] preorder3 = { }, inorder3 = { };
            Assert.Throws<ArgumentException>(() => RebuildBinaryTree.Execute(preorder3, inorder3));

            int[] preorder4 = { 3, 8 }, inorder4 = { 1, 2 };
            Assert.Throws<ArgumentException>(() => RebuildBinaryTree.Execute(preorder4, inorder4));
        }

        [Fact]
        public void TestInvalidInput()
        {
            // 这是经过设计的数据,在选取根节点后,左子树部分数据不一致,故而不能生成二叉树
            int[] preorder = { 1, 2, 3, 8 }, inorder = { 2, 8, 1, 3 };
            Assert.Throws<ArgumentException>(() => RebuildBinaryTree.Execute(preorder, inorder));
        }

        [Fact]
        public void TestSpecialInput()
        {
            int[] preorder = { 1 }, inorder = { 1 };
            BinaryTreeNode<int> root = RebuildBinaryTree.Execute(preorder, inorder);

            Assert.True(root.Value == 1);
            Assert.Null(root.Right);
            Assert.Null(root.Left);
        }

        [Fact]
        public void TestFullTree()
        {
            int[] preorder = { 1, 2, 4, 5, 3, 6, 7 };
            int[] inorder = { 4, 2, 5, 1, 6, 3, 7 };

            // 验证重建的树结构是否与原始树一致
            BinaryTreeNode<int> root = RebuildBinaryTree.Execute(preorder, inorder);
            Assert.True(root.Value == 1);

            // 2
            Assert.True(root.Left.Value == 2);

            // 4
            Assert.True(root.Left.Left.Value == 4);
            Assert.Null(root.Left.Left.Left);
            Assert.Null(root.Left.Left.Right);

            // 5
            Assert.True(root.Left.Right.Value == 5);
            Assert.Null(root.Left.Right.Left);
            Assert.Null(root.Left.Right.Right);

            // 3
            Assert.True(root.Right.Value == 3);

            // 6
            Assert.True(root.Right.Left.Value == 6);
            Assert.Null(root.Right.Left.Left);
            Assert.Null(root.Right.Left.Right);

            // 7
            Assert.True(root.Right.Right.Value == 7);
            Assert.Null(root.Right.Right.Right);
            Assert.Null(root.Right.Right.Left);
        }

        [Fact]
        public void TestTreeWithOnlyRightChild()
        {
            int[] preorder = { 1, 2, 3, 4 };
            int[] inorder = { 1, 2, 3, 4 };

            // 验证重建的树结构是否与原始树一致
            BinaryTreeNode<int> root = RebuildBinaryTree.Execute(preorder, inorder);
            Assert.True(root.Value == 1);
            Assert.Null(root.Left);

            // 2
            Assert.True(root.Right.Value == 2);

            // 3
            Assert.True(root.Right.Right.Value == 3);
            Assert.Null(root.Right.Right.Left);

            // 4
            Assert.True(root.Right.Right.Right.Value == 4);
            Assert.Null(root.Right.Right.Right.Left);
        }

        [Fact]
        public void TestTreeWithOnlyLeftChild()
        {
            int[] preorder = { 1, 2, 3, 4 };
            int[] inorder = { 4, 3, 2, 1 };

            // 验证重建的树结构是否与原始树一致
            BinaryTreeNode<int> root = RebuildBinaryTree.Execute(preorder, inorder);
            Assert.True(root.Value == 1);
            Assert.Null(root.Right);

            // 2
            Assert.True(root.Left.Value == 2);
            Assert.Null(root.Left.Right);

            // 3
            Assert.True(root.Left.Left.Value == 3);
            Assert.Null(root.Left.Left.Right);

            // 4
            Assert.True(root.Left.Left.Left.Value == 4);
            Assert.Null(root.Left.Left.Left.Right);
        }
    }
}
