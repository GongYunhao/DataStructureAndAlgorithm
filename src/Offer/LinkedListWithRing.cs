using System;
using CommonModels;

namespace Offer
{
    public class LinkedListWithRing
    {
        public static MyLinkedListNode FindEntry(ref MyLinkedListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head), "The linked list head can't be null");

            MyLinkedListNode meetingNode = FindMeetingNode(ref head);
            if (meetingNode == null)
                return null;

            // 从上面返回的相遇节点出发,绕过一周回到相遇节点,经过的节点数即为环上的节点数
            int nodeCountInLoop = 1;
            MyLinkedListNode countingNode = meetingNode;
            while (countingNode.Next != meetingNode)
            {
                nodeCountInLoop++;
                countingNode = countingNode.Next;
            }

            // 仿照查找链表中倒数第k个节点的代码
            // 维护两个指针,其中一个先移动相当于环上总节点数的节点,然后两个指针同时移动
            // 当第一个指针经过环上一周,并与第二个指针相遇时,两个个指针恰好位于环的入口节点上
            MyLinkedListNode rightNode = head;
            for (int i = 0; i < nodeCountInLoop; i++)
            {
                rightNode = rightNode.Next;
            }

            MyLinkedListNode leftNode = head;
            while (rightNode != leftNode)// 两个指针相遇的时候,恰好位于环的入口节点上,此时结束循环
            {
                leftNode = leftNode.Next;
                rightNode = rightNode.Next;
            }

            return leftNode;
        }

        /// <summary>
        /// 设定两个指针在链表上移动,一个一次移动一个节点,另一个一次移动两个节点
        /// 当两个指针相遇时,相遇节点一定在环上;如果指针没有相遇就到达了链表尾部,说明环不存在
        /// </summary>
        /// <param name="head">链表的头节点</param>
        /// <returns>两个指针相遇的节点</returns>
        private static MyLinkedListNode FindMeetingNode(ref MyLinkedListNode head)
        {
            MyLinkedListNode pFast = head.Next, pSlow = head;

            while (pFast != null && pSlow != null)
            {
                if (pFast == pSlow)
                    return pFast;
                pSlow = pSlow.Next;
                pFast = pFast.Next;
                pFast = pFast?.Next;
            }

            return null;
        }
    }
}
