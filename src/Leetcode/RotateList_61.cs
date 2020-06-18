using System;
using CommonModels;

namespace Leetcode
{
    public class RotateList_61
    {
        // this method will go through the list twice, time complexity is O(N)
        // in first loop, will work out list length
        // then adjust k to avoid unnecessary rotations
        // in second loop, use two pointers to locate end of old list & end of new list
        public MyLinkedListNode RotateRight(MyLinkedListNode head, int k)
        {
            // invalid input
            if (k < 0)
                throw new ArgumentException();

            // list is empty, one-node, or no rotation
            if (head == null || head.Next == null || k == 0)
                return head;

            // get the length of list
            int listLength = 1;
            MyLinkedListNode currentNode = head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                listLength++;
            }

            // adjust k to avoid unnecessary rotations
            k %= listLength;
            if (k == 0)
                return head;

            // use tow pointers to locate end of old list & end of new list
            MyLinkedListNode fastPointer = head;
            for (int i = 0; i < k; i++)
                fastPointer = fastPointer.Next;
            MyLinkedListNode slowPointer = head;
            while (fastPointer.Next != null)
            {
                fastPointer = fastPointer.Next;
                slowPointer = slowPointer.Next;
            }

            // reform the linked list
            fastPointer.Next = head;
            MyLinkedListNode newHead = slowPointer.Next;
            slowPointer.Next = null;
            return newHead;
        }
    }
}
