using System;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class MergeTwoSortedLinkedlistTest
    {
        private MyLinkedListNode GenerateRandomLinkedList(int count, int max)
        {
            Random _random = new Random();
            int[] intArray = new int[count];
            for (int i = 0; i < count; i++)
                intArray[i] = _random.Next(max);

            Array.Sort(intArray, (a, b) => a - b);

            MyLinkedListNode head = null, current = null;
            for (int i = 0; i < count; i++)
            {
                MyLinkedListNode node = new MyLinkedListNode(intArray[i]);

                if (head == null)
                {
                    head = node;
                    current = head;
                }
                else
                {
                    current.Next = node;
                    current = node;
                }
            }

            return head;
        }

        [Fact]
        public void NormalInput()
        {
            MyLinkedListNode list1 = GenerateRandomLinkedList(200, 500);
            MyLinkedListNode list2 = GenerateRandomLinkedList(100, 500);

            MyLinkedListNode newList = MergeTwoSortedLinkedlist.Merge(list1, list2);

            MyLinkedListNode currentNode = newList;
            MyLinkedListNode nextNode = newList.Next;

            while (nextNode != null)
            {
                Assert.True(currentNode.Value <= nextNode.Value);
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            Assert.Null(nextNode);
        }

        [Fact]
        public void TestWithOneNullList()
        {
            MyLinkedListNode list1 = GenerateRandomLinkedList(200, 500);

            MyLinkedListNode newList = MergeTwoSortedLinkedlist.Merge(list1, null);

            MyLinkedListNode currentNode = newList;
            MyLinkedListNode nextNode = newList.Next;

            while (nextNode != null)
            {
                Assert.True(currentNode.Value <= nextNode.Value);
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            Assert.Null(nextNode);
        }

        [Fact]
        public void TestWithTwoNullList()
        {
            MyLinkedListNode newList = MergeTwoSortedLinkedlist.Merge(null, null);
            Assert.Null(newList);
        }

        [Fact]
        public void TestWithOneListThatContainsOneNode()
        {
            MyLinkedListNode list1 = new MyLinkedListNode(23);
            MyLinkedListNode list2 = new MyLinkedListNode(47);

            MyLinkedListNode newList = MergeTwoSortedLinkedlist.Merge(list1, list2);
            Assert.True(newList.Value <= newList.Next.Value);
            Assert.Null(newList.Next.Next);
        }
    }
}
