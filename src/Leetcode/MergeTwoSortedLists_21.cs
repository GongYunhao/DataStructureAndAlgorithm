using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Leetcode
{
    public class MergeTwoSortedLists_21
    {
        public MyLinkedListNode MergeTwoLists(MyLinkedListNode l1, MyLinkedListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            // 定义两个节点对象，一个代表结果链表的头节点，另一个代表生成结果链表过程中的中间变量
            MyLinkedListNode head = null;
            MyLinkedListNode current = null;

            // 确定哪个节点将作为头节点（如果不在此处赋值，那就只能在循环中判断head==null后赋值，没有必要）
            if (l1.Value <= l2.Value)
            {
                head = l1;
                l1 = l1.Next;
            }
            else
            {
                head = l2;
                l2 = l2.Next;
            }
            current = head;

            // 当l1和l2同时不为null的时候，判断节点值大小，拼接到结果链表中
            while (l1 != null && l2 != null)
            {
                if (l1.Value <= l2.Value)
                {
                    current.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    current.Next = l2;
                    l2 = l2.Next;
                }

                current = current.Next;
            }

            // 当l1和l2中有一个为null时，就不需要判断了，可以将剩余链表全部接到结果链表后
            if (l1 == null)
                current.Next = l2;
            else
                current.Next = l1;

            return head;
        }
    }
}
