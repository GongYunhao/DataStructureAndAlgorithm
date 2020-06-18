using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class DeleteDuplicateLinkedNodesTest
    {
        [Fact]
        public void NormalTest()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 4, 4, 5, 6, 7, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteDuplicatedLinkedNodes.Delete(ref head);

            MyLinkedListNode currentNode = head;
            int[] set = { 1, 2, 3, 5, 6, 8, 9 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        [Fact]
        public void TestWithAllNodesDeleted()
        {
            MyLinkedListNode head = new MyLinkedListNode(4);
            MyLinkedListNode current = head;

            int[] source = { 4, 4, 4, 4, 4, 4 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteDuplicatedLinkedNodes.Delete(ref head);

            Assert.Null(head);
        }

        [Fact]
        public void TestWithHeadsDeleted()
        {
            MyLinkedListNode head = new MyLinkedListNode(4);
            MyLinkedListNode current = head;

            int[] source = { 4, 4, 4, 5, 6, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteDuplicatedLinkedNodes.Delete(ref head);

            MyLinkedListNode currentNode = head;
            int[] set = { 5, 6, 8, 9 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        [Fact]
        public void TestWithTailsDeleted()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 4, 5, 6, 8, 9, 20, 20, 20 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteDuplicatedLinkedNodes.Delete(ref head);

            MyLinkedListNode currentNode = head;
            int[] set = { 1, 4, 5, 6, 8, 9 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        [Fact]
        public void TestWithNoNodeDeleted()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 4, 5, 6, 8, 9, 20 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteDuplicatedLinkedNodes.Delete(ref head);

            MyLinkedListNode currentNode = head;
            int[] set = { 1, 4, 5, 6, 8, 9, 20 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        [Fact]
        public void OnlyOneNodeInLinkedList()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            DeleteDuplicatedLinkedNodes.Delete(ref head);
            Assert.Equal(1, head.Value);
            Assert.Null(head.Next);
        }

        [Fact]
        public void TestWithInvalidInput()
        {
            MyLinkedListNode head = null;
            Assert.Throws<ArgumentNullException>
            (
                () => DeleteDuplicatedLinkedNodes.Delete(ref head)
            );
        }
    }
}
