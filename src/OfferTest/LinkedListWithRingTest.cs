using System;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class LinkedListWithRingTest
    {
        [Fact]
        public void TestLinkedListWithRing()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 25, 67, 98 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            current.Next = head.Next.Next.Next;// 4为入口节点

            Assert.Equal(4, LinkedListWithRing.FindEntry(ref head).Value);
        }

        [Fact]
        public void TestAnotherLinkedListWithRing()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            current.Next = head;// 1为入口节点
            Assert.Equal(1, LinkedListWithRing.FindEntry(ref head).Value);

            // 修改入口点到尾节点
            current.Next = current;
            Assert.Equal(9, LinkedListWithRing.FindEntry(ref head).Value);
        }

        [Fact]
        public void TestLinkedListWithoutRing()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            Assert.Null(LinkedListWithRing.FindEntry(ref head));
        }

        [Fact]
        public void TestOneNodeLinkedListWithoutRing()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            Assert.Null(LinkedListWithRing.FindEntry(ref head));
        }

        [Fact]
        public void TestOneNodeLinkedListWithRing()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            head.Next = head;
            Assert.Equal(1, LinkedListWithRing.FindEntry(ref head).Value);
        }

        [Fact]
        public void TestInvalidInput()
        {
            MyLinkedListNode head = null;
            Assert.Throws<ArgumentNullException>(() => LinkedListWithRing.FindEntry(ref head));
        }
    }
}
