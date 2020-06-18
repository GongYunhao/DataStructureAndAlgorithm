using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class DeleteNodeFromLinkedListTest
    {
        /// <summary>
        /// 功能测试-从链表中间位置删除一个节点
        /// </summary>
        [Fact]
        public void NormalTest()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteNodeFromLinkedList.Delete(ref head, head.Next.Next.Next.Next);

            MyLinkedListNode currentNode = head;
            int[] set = { 1, 2, 3, 4, 6, 7, 8, 9 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        /// <summary>
        /// 特殊情况-从链表的开头位置删除
        /// </summary>
        [Fact]
        public void TestWhenGivenNodeIsFirst()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteNodeFromLinkedList.Delete(ref head, head);

            MyLinkedListNode currentNode = head;
            int[] set = {  2, 3, 4,5, 6, 7, 8, 9 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        /// <summary>
        /// 特殊情况-从链表的末尾删除
        /// </summary>
        [Fact]
        public void TestWhenGivenNodeIsLast()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteNodeFromLinkedList.Delete(ref head, head.Next.Next.Next.Next.Next.Next.Next.Next);

            MyLinkedListNode currentNode = head;
            int[] set = { 1, 2, 3, 4,5, 6, 7, 8 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        /// <summary>
        /// 特殊情况-链表只包含一个节点
        /// </summary>
        [Fact]
        public void TestWithOnlyOneNode()
        {
            MyLinkedListNode node = new MyLinkedListNode(20);

            DeleteNodeFromLinkedList.Delete(ref node, node);

            Assert.Null(node);
        }

        /// <summary>
        /// 异常情况-给定节点不在链表中
        /// </summary>
        [Fact]
        public void TestWithNodeNotBelongsToList()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            MyLinkedListNode current = head;

            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 1; i < source.Length; i++)
            {
                current.Next = new MyLinkedListNode(source[i]);
                current = current.Next;
            }

            DeleteNodeFromLinkedList.Delete(ref head, new MyLinkedListNode(9));//采用object.==比对节点,所以即使Value一致,也不会认为是链表中的节点

            MyLinkedListNode currentNode = head;
            int[] set = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < set.Length; i++)
            {
                Assert.Equal(set[i], currentNode.Value);
                currentNode = currentNode.Next;
            }
            Assert.Null(currentNode);
        }

        /// <summary>
        /// 异常输入
        /// </summary>
        [Fact]
        public void TestInvalidInput()
        {
            MyLinkedListNode head = null;
            Assert.Throws<ArgumentNullException>
            (
                () => DeleteNodeFromLinkedList.Delete(ref head, new MyLinkedListNode(30))
            );

            MyLinkedListNode head1 = new MyLinkedListNode(2);
            Assert.Throws<ArgumentNullException>
            (
                () => DeleteNodeFromLinkedList.Delete(ref head1, null)
            );
        }
    }
}
