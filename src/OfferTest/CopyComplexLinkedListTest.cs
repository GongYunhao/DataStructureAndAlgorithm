using System;
using System.Collections.Generic;
using CommonModels;
using Offer;
using Xunit;

namespace OfferTest
{
    public class CopyComplexLinkedListTest
    {
        [Fact]
        public void LinkedListWithSiblingsAndRings()
        {
            var nodeList = new List<ComplexLinkedListNode>
            {
                new ComplexLinkedListNode(1),new ComplexLinkedListNode(2),new ComplexLinkedListNode(3),new ComplexLinkedListNode(4),
                new ComplexLinkedListNode(5),new ComplexLinkedListNode(6),new ComplexLinkedListNode(7),new ComplexLinkedListNode(8),
                new ComplexLinkedListNode(9),new ComplexLinkedListNode(10)
            };

            for (int i = 0; i <= nodeList.Count - 2; i++)
            {
                nodeList[i].Next = nodeList[i + 1];
            }

            nodeList[2].Sibling = nodeList[6];
            nodeList[4].Sibling = nodeList[1];
            nodeList[7].Sibling = nodeList[8];
            nodeList[8].Sibling = nodeList[7];

            var newHead = CopyComplexLinkedList.Execute(nodeList[0]);

            var newNodeList = new List<ComplexLinkedListNode> { newHead };

            while (newHead.Next != null)
            {
                newHead = newHead.Next;
                newNodeList.Add(newHead);
            }

            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                Assert.NotEqual(nodeList[i], newNodeList[i]);// 确保两个链表中的对象都是不一致的
                Assert.Equal(nodeList[i].Value, newNodeList[i].Value);

                if (i != 2 && i != 4 && i != 7 && i != 8)
                    Assert.Null(newNodeList[i].Sibling);
            }

            Assert.Equal(newNodeList[6], newNodeList[2].Sibling);
            Assert.Equal(newNodeList[1], newNodeList[4].Sibling);
            Assert.Equal(newNodeList[8], newNodeList[7].Sibling);
            Assert.Equal(newNodeList[7], newNodeList[8].Sibling);
        }

        [Fact]
        public void LinkedListWithOnlyOneNode()
        {
            var oldNode = new ComplexLinkedListNode(20);
            var newNode = CopyComplexLinkedList.Execute(oldNode);
            Assert.Equal(oldNode.Value, newNode.Value);
            Assert.NotEqual(oldNode, newNode);
            Assert.Null(oldNode.Next);
            Assert.Null(newNode.Next);
            Assert.Null(oldNode.Sibling);
            Assert.Null(newNode.Sibling);
        }

        [Fact]
        public void LinkedListWithOnlyOneNodeAndHasItselfAsSibling()
        {
            var oldNode = new ComplexLinkedListNode(20);
            oldNode.Sibling = oldNode;
            var newNode = CopyComplexLinkedList.Execute(oldNode);
            Assert.Equal(oldNode.Value, newNode.Value);
            Assert.NotEqual(oldNode, newNode);
            Assert.Null(oldNode.Next);
            Assert.Null(newNode.Next);
            Assert.Equal(newNode, newNode.Sibling);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => CopyComplexLinkedList.Execute(null));
        }
    }
}
