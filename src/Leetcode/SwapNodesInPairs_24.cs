using CommonModels;

namespace Leetcode
{
    public class SwapNodesInPairs_24
    {
        public MyLinkedListNode SwapPairs(MyLinkedListNode head)
        {
            if (head == null || head.Next == null)
                return null;

            MyLinkedListNode preNode = null;
            MyLinkedListNode leftNode = head;
            MyLinkedListNode rightNode = head.Next;
            MyLinkedListNode afterNode = rightNode.Next;

            MyLinkedListNode result = null;

            while (rightNode != null)
            {
                if (preNode != null)
                {
                    preNode.Next = rightNode;
                }
                rightNode.Next = leftNode;
                leftNode.Next = afterNode;

                if (result == null)
                    result = rightNode;

                preNode = leftNode;
                leftNode = afterNode;
                rightNode = afterNode != null ? afterNode.Next : null;
                afterNode = rightNode != null ? rightNode.Next : null;
            }

            return result;
        }
    }
}
