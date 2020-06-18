using System;
using CommonModels;

namespace Offer
{
    public class LastKstNodeInLinkedlist
    {
        public static MyLinkedListNode Execute(ref MyLinkedListNode head, int k)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head), "The head of linked list can't be null");
            if (k <= 0)
                throw new ArgumentException("The given k can't be zero or smaller");

            MyLinkedListNode rightNode = head;
            // 因为k的最小值为1,所以此处从2开始计数:k=1时,右指针指向头节点,而且不会运行下面的循环代码
            // k=2时,运行一次,也与预想的一致
            // 换种想法,算法需要右指针先往前走k-1步,所以从2开始,直到i=k
            for (int i = 2; i <= k; i++)
            {
                rightNode = rightNode.Next;

                // 遍历过程中就有可能越过尾节点,所以每个循环都要判断一下
                if (rightNode == null)
                    return null;
            }

            MyLinkedListNode leftNode = head;
            while (rightNode.Next != null)
            {
                leftNode = leftNode.Next;
                rightNode = rightNode.Next;
            }

            return leftNode;
        }
    }
}
