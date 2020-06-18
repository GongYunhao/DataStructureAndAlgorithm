using System;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class LastKstNodeInLinkedlistTest
    {
        [Fact]
        public void NormalLinkedList()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            Assert.Equal(1, LastKstNodeInLinkedlist.Execute(ref head, 9).Value);
            Assert.Equal(5, LastKstNodeInLinkedlist.Execute(ref head, 5).Value);
            Assert.Equal(7, LastKstNodeInLinkedlist.Execute(ref head, 3).Value);
            Assert.Equal(9, LastKstNodeInLinkedlist.Execute(ref head, 1).Value);
            Assert.Null(LastKstNodeInLinkedlist.Execute(ref head, 10));
            Assert.Null(LastKstNodeInLinkedlist.Execute(ref head, 11));
        }

        [Fact]
        public void SpecialTest()
        {
            MyLinkedListNode node = new MyLinkedListNode(23);
            Assert.Equal(23, LastKstNodeInLinkedlist.Execute(ref node, 1).Value);
        }

        [Fact]
        public void InvaliInput()
        {
            MyLinkedListNode node = null;
            Assert.Throws<ArgumentNullException>(() => LastKstNodeInLinkedlist.Execute(ref node, 1));

            MyLinkedListNode node1 = new MyLinkedListNode(23);
            Assert.Throws<ArgumentException>(() => LastKstNodeInLinkedlist.Execute(ref node1, -1));
            Assert.Throws<ArgumentException>(() => LastKstNodeInLinkedlist.Execute(ref node1, 0));
        }
    }
}
