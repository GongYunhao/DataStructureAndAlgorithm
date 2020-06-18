using System;
using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class RemoveNthNodeFromEndOfListTest
    {
        [Fact]
        public void NormalTest()
        {
            MyLinkedListNode head = new MyLinkedListNode(1)
            {
                Next = new MyLinkedListNode(2)
                {
                    Next = new MyLinkedListNode(3)
                    {
                        Next = new MyLinkedListNode(4)
                        {
                            Next = new MyLinkedListNode(5)
                            {
                                Next = new MyLinkedListNode(6)
                            }
                        }
                    }
                }
            };

            var result = new RemoveNthNodeFromEndOfList_19().RemoveNthFromEnd(head, 3);

            Assert.Equal(1, result.Value);
            Assert.Equal(2, result.Next.Value);
            Assert.Equal(3, result.Next.Next.Value);
            Assert.Equal(5, result.Next.Next.Next.Value);
            Assert.Equal(6, result.Next.Next.Next.Next.Value);
            Assert.Null(result.Next.Next.Next.Next.Next);
        }

        [Fact]
        public void OneNodeLinkedList()
        {
            MyLinkedListNode head = new MyLinkedListNode(1);
            var result = new RemoveNthNodeFromEndOfList_19().RemoveNthFromEnd(head, 1);
            Assert.Null(result);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveNthNodeFromEndOfList_19().RemoveNthFromEnd(null, 1));
            Assert.Throws<ArgumentException>(() => new RemoveNthNodeFromEndOfList_19().RemoveNthFromEnd(new MyLinkedListNode(2), 0));

            Assert.Throws<ArgumentException>(() => new RemoveNthNodeFromEndOfList_19().RemoveNthFromEnd(new MyLinkedListNode(2), 3));
        }
    }
}
