using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Offer
{
    public class DeleteDuplicatedLinkedNodes
    {
        public static void Delete(ref MyLinkedListNode head)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head), "The parameter can't be null");

            // 虚拟一个根节点出来,便于处理边界情况
            MyLinkedListNode root = new MyLinkedListNode(-1) { Next = head };
            MyLinkedListNode preNode = root;// 位于重复区域前的节点,即preNode.Next节点位于重复区域的起始位置
            // 以下两节点为一组,同时移动:其中nodeBeforeRightNode属于重复区域内最后一个节点,rightNode属于重复区域外第一个节点
            MyLinkedListNode nodeBeforeRightNode = head;
            MyLinkedListNode rightNode = head.Next;

            // 代码的主要思想可参考文件夹下的图片
            bool isDuplicated = false;
            while (nodeBeforeRightNode != null)
            {
                if (rightNode == null)
                {
                    if (isDuplicated)
                        preNode.Next = rightNode;
                }
                else
                {
                    if (rightNode.Value == preNode.Next.Value)
                    {
                        isDuplicated = true;
                    }
                    else if (isDuplicated)
                    {
                        preNode.Next = rightNode;
                        isDuplicated = false;
                    }
                    else
                    {
                        preNode = nodeBeforeRightNode;
                    }
                }

                nodeBeforeRightNode = rightNode;
                rightNode = rightNode?.Next;
            }

            head = root.Next;
        }
    }
}
