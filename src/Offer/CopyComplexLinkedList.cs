using System;
using System.Collections;
using CommonModels;

namespace Offer
{
    public class CopyComplexLinkedList
    {
        public static ComplexLinkedListNode Execute(ComplexLinkedListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head), "The input linked list can't be null");

            //return CopyUsingHash(head);
            return Copy(head);
        }

        private static ComplexLinkedListNode Copy(ComplexLinkedListNode head)
        {
            // 将每个节点复制后,就接在本节点后面,再往后才是剩下的节点
            var currentNode = head;
            var nextNode = head.Next;
            while (currentNode != null)
            {
                var newNode = new ComplexLinkedListNode(currentNode.Value);
                currentNode.Next = newNode;
                newNode.Next = nextNode;

                currentNode = nextNode;
                nextNode = nextNode?.Next;
            }

            // 重建sibling关系
            currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Sibling != null)
                    currentNode.Next.Sibling = currentNode.Sibling.Next;

                currentNode = currentNode.Next.Next;
            }

            // 拆分出新链表,并且会还原原始链表
            var old = head;
            var oldToNew = head.Next;
            var newHead = oldToNew;
            var newCurrent = newHead;
            while (oldToNew.Next != null)
            {
                old.Next = oldToNew.Next;
                old = old.Next;

                oldToNew = oldToNew.Next.Next;
                newCurrent.Next = oldToNew;

                newCurrent = newCurrent.Next;
            }

            // 上面循环结束的时候,原链表最后一个节点指向的是新链表最后一个节点,需要手动指向null,才能完全恢复原始链表
            old.Next = null;

            return newHead;
        }

        // 利用hash关联新旧两个链表中的值,时间效率很高,但是需要占用额外空间
        private static ComplexLinkedListNode CopyUsingHash(ComplexLinkedListNode head)
        {
            var newHead = new ComplexLinkedListNode(head.Value);
            Hashtable hash = new Hashtable
            {
                { head, newHead }
            };

            // 复制链表
            var oldCurrent = head;
            var newCurrent = newHead;
            while (oldCurrent.Next != null)
            {
                oldCurrent = oldCurrent.Next;

                newCurrent.Next = new ComplexLinkedListNode(oldCurrent.Value);
                newCurrent = newCurrent.Next;
                // 记录新旧链表对应节点的关系,这样在第二轮遍历重建Sibling关系时,只需要O(1)的查找时间
                hash.Add(oldCurrent, newCurrent);
            }

            // 重建Sibling关系
            oldCurrent = head;
            newCurrent = newHead;
            while (oldCurrent != null)
            {
                // 当旧链表节点有Sibling节点时,给新链表也加上对应的关系(通过hash查找加快速度)
                if (oldCurrent.Sibling != null)
                    newCurrent.Sibling = (ComplexLinkedListNode)hash[oldCurrent.Sibling];

                oldCurrent = oldCurrent.Next;
                newCurrent = newCurrent.Next;
            }

            return newHead;
        }
    }
}
