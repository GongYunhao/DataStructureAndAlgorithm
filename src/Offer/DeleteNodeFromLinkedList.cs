using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Offer
{
    public class DeleteNodeFromLinkedList
    {
        public static void Delete(ref MyLinkedListNode head, MyLinkedListNode node)
        {
            if (head == null)
                throw new ArgumentNullException("The input linked list can't be null");
            if (node == null)
                throw new ArgumentNullException("The input node can't be null");

            // 删除的节点不是尾节点
            if (node.Next != null)
            {
                // 将下一个节点的值赋给要删除的节点,并将下下个节点链接到当前节点的next属性下,相当于删除了下个节点,但是保留了值
                // 在面向对象编程语言中,这么做可能有风险,因为正常情况下应该是根据object的equals属性来判断节点,而不能仅仅根据节点的值来判断
                node.Value = node.Next.Value;
                node.Next = node.Next.Next;
            }
            else if (head == node)// 删除的节点是尾节点,并且头节点就是尾节点(即链表中只有一个节点)
            {
                head = null;
            }
            else// 要删除的节点是尾节点,并且链表中有多个节点,需要从头节点遍历到倒数第二个节点
            {
                MyLinkedListNode currentNode = head;
                while (currentNode.Next != node)
                {
                    if (currentNode.Next == null)
                    {
                        //表示已遍历到链表的末尾,可以判断给定节点不存在于链表中
                        return;
                    }
                    currentNode = currentNode.Next;
                }

                currentNode.Next = null;
            }
        }
    }
}
