using System;
using CommonModels;
using Offer;
using Xunit;

namespace OfferTest
{
    public class SerializeBinaryTreeTest
    {
        [Fact]
        public void Serialize()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(4)
                },
                Right = new BinaryTreeNode<int>(3)
                {
                    Left = new BinaryTreeNode<int>(5),
                    Right = new BinaryTreeNode<int>(6)
                }
            };

            Assert.Equal("1,2,4,$,$,$,3,5,$,$,6,$,$", SerializeBinaryTree.Serialize(root));
        }

        [Fact]
        public void Deserialize()
        {
            BinaryTreeNode<int> newRoot = SerializeBinaryTree.Deserialize("1,2,4,$,$,$,3,5,$,$,6,$,$");
            Assert.Equal(1, newRoot.Value);
            Assert.Equal(2, newRoot.Left.Value);
            Assert.Equal(3, newRoot.Right.Value);

            Assert.Equal(4, newRoot.Left.Left.Value);
            Assert.Equal(5, newRoot.Right.Left.Value);
            Assert.Equal(6, newRoot.Right.Right.Value);

            Assert.Null(newRoot.Left.Right);
            Assert.Null(newRoot.Left.Left.Right);
            Assert.Null(newRoot.Left.Left.Left);
            Assert.Null(newRoot.Right.Left.Left);
            Assert.Null(newRoot.Right.Left.Right);
            Assert.Null(newRoot.Right.Right.Left);
            Assert.Null(newRoot.Right.Right.Right);
        }

        [Fact]
        public void SerializeWithMerelyLeftNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(4)
                    {
                        Left = new BinaryTreeNode<int>(20)
                        {
                            Left = new BinaryTreeNode<int>(45)
                        }
                    }
                }
            };

            Assert.Equal("1,2,4,20,45,$,$,$,$,$,$", SerializeBinaryTree.Serialize(root));
        }

        [Fact]
        public void DeserializeWithMerelyLeftNode()
        {
            BinaryTreeNode<int> newRoot = SerializeBinaryTree.Deserialize("1,2,4,20,45,$,$,$,$,$,$");
            Assert.Equal(1, newRoot.Value);
            Assert.Equal(2, newRoot.Left.Value);
            Assert.Equal(4, newRoot.Left.Left.Value);
            Assert.Equal(20, newRoot.Left.Left.Left.Value);
            Assert.Equal(45, newRoot.Left.Left.Left.Left.Value);

            Assert.Null(newRoot.Right);
            Assert.Null(newRoot.Left.Right);
            Assert.Null(newRoot.Left.Left.Right);
            Assert.Null(newRoot.Left.Left.Left.Right);
            Assert.Null(newRoot.Left.Left.Left.Left.Left);
            Assert.Null(newRoot.Left.Left.Left.Left.Right);
        }

        [Fact]
        public void SerializeWithOnlyOneNode()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1);
            Assert.Equal("1,$,$", SerializeBinaryTree.Serialize(root));
            BinaryTreeNode<int> newRoot = SerializeBinaryTree.Deserialize("1,$,$");
            Assert.Equal(1, newRoot.Value);
            Assert.Null(newRoot.Right);
            Assert.Null(newRoot.Left);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => SerializeBinaryTree.Serialize(null));
            Assert.Throws<ArgumentNullException>(() => SerializeBinaryTree.Deserialize(null));
            Assert.Null(SerializeBinaryTree.Deserialize("56"));

            // 缺少足够的$字符
            Assert.Throws<ArgumentException>(() => SerializeBinaryTree.Deserialize("1,2,3,6,5,4,7"));

            // 有多余的字符
            Assert.Throws<ArgumentException>(() => SerializeBinaryTree.Deserialize("1,2,4,20,45,$,$,$,$,$,$,6"));
        }
    }
}
