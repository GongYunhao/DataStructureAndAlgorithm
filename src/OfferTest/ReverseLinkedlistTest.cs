using System;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class ReverseLinkedlistTest
    {
        [Fact]
        public void LinkedListWithMultipleNodes()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            ReverseLinkedlist.Reverse(ref head);

            for (int i = source.Length - 1; i >= 0; i--)
            {
                Assert.Equal(source[i], current.Value);
                current = current.Next;
            }
            Assert.Null(current);
        }

        [Fact]
        public void LinkedListWithTwoNodes()
        {
            MyLinkedListNode head = new MyLinkedListNode(23);
            MyLinkedListNode current = head;

            int[] source = { 23, 10 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            ReverseLinkedlist.Reverse(ref head);

            for (int i = source.Length - 1; i >= 0; i--)
            {
                Assert.Equal(source[i], current.Value);
                current = current.Next;
            }
            Assert.Null(current);
        }

        [Fact]
        public void LinkedListWithOneNodes()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            ReverseLinkedlist.Reverse(ref head);
            Assert.Equal(1, head.Value);
            Assert.Null(head.Next);
        }

        [Fact]
        public void InvalidInput()
        {
            MyLinkedListNode head = null;
            Assert.Throws<ArgumentNullException>(() => ReverseLinkedlist.Reverse(ref head));
        }
    }
}
