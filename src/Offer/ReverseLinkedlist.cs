using System;
using CommonModels;

namespace Offer
{
    public class ReverseLinkedlist
    {
        public static MyLinkedListNode Reverse(ref MyLinkedListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head), "The input linked list head can't be null");

            MyLinkedListNode leftNode = null;
            MyLinkedListNode middleNode = null;
            MyLinkedListNode rightNode = head;

            // 可以看作架梁机的原理,先移动,然后修改链表方向,最后判断是否继续下一个步骤
            while (rightNode != null)
            {
                leftNode = middleNode;
                middleNode = rightNode;
                rightNode = rightNode.Next;

                middleNode.Next = leftNode;
            }

            return middleNode;
        }
    }
}
