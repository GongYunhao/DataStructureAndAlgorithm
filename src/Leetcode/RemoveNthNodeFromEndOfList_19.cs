using System;
using CommonModels;

namespace Leetcode
{
    public class RemoveNthNodeFromEndOfList_19
    {
        public MyLinkedListNode RemoveNthFromEnd(MyLinkedListNode head, int n)
        {
            if (head == null)
                throw new ArgumentNullException();
            if (n <= 0)
                throw new ArgumentException();

            MyLinkedListNode dummy = new MyLinkedListNode(-1);
            dummy.Next = head;

            MyLinkedListNode fast = head;
            for (int i = 1; i < n; i++)
            {
                if (fast != null)
                    fast = fast.Next;
                else
                    throw new ArgumentException();
            }
            MyLinkedListNode slow = dummy;

            while (fast.Next != null)
            {
                fast = fast.Next;
                slow = slow.Next;
            }

            slow.Next = slow.Next.Next;

            return dummy.Next;
        }
    }
}
