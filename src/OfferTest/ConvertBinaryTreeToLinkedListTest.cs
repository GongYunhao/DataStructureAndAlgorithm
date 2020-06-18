using System;
using CommonModels;
using Offer;
using Xunit;

namespace OfferTest
{
    public class ConvertBinaryTreeToLinkedListTest
    {
        [Fact]
        public void NormalBinarySearchTree()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10)
            {
                Left = new BinaryTreeNode<int>(6)
                {
                    Left = new BinaryTreeNode<int>(4),
                    Right = new BinaryTreeNode<int>(8)
                },
                Right = new BinaryTreeNode<int>(14)
                {
                    Left = new BinaryTreeNode<int>(12),
                    Right = new BinaryTreeNode<int>(16)
                }
            };

            var head = ConvertBinaryTreeToLinkedList.GetHead(root);

            int[] sources = { 4, 6, 8, 10, 12, 14, 16 };

            // 从左右两个方向确认链表正确链接,并且两头都是null节点
            var currentNode = head;
            for (int i = 0; i < sources.Length; i++)
            {
                Assert.Equal(sources[i], currentNode.Value);
                currentNode = currentNode.Right ?? currentNode;
            }
            Assert.Null(currentNode.Right);

            for (int i = sources.Length - 1; i >= 0; i--)
            {
                Assert.Equal(sources[i], currentNode.Value);
                currentNode = currentNode.Left ?? currentNode;
            }
            Assert.Null(currentNode.Left);
        }

        [Fact]
        public void BinarySearchTreeWithOnlyRightNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10)
            {
                Right = new BinaryTreeNode<int>(14)
                {
                    Right = new BinaryTreeNode<int>(16)
                    {
                        Right = new BinaryTreeNode<int>(166)
                    }
                }
            };

            var head = ConvertBinaryTreeToLinkedList.GetHead(root);

            int[] sources = { 10, 14, 16, 166 };

            // 从左右两个方向确认链表正确链接,并且两头都是null节点
            var currentNode = head;
            for (int i = 0; i < sources.Length; i++)
            {
                Assert.Equal(sources[i], currentNode.Value);
                currentNode = currentNode.Right ?? currentNode;
            }
            Assert.Null(currentNode.Right);

            for (int i = sources.Length - 1; i >= 0; i--)
            {
                Assert.Equal(sources[i], currentNode.Value);
                currentNode = currentNode.Left ?? currentNode;
            }
            Assert.Null(currentNode.Left);
        }

        [Fact]
        public void TreeWithOnlyOneNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(10);
            var head = ConvertBinaryTreeToLinkedList.GetHead(root);
            Assert.Equal(head, root);
            Assert.Equal(10, root.Value);
            Assert.Null(root.Left);
            Assert.Null(root.Right);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => ConvertBinaryTreeToLinkedList.GetHead(null));
        }
    }
}
