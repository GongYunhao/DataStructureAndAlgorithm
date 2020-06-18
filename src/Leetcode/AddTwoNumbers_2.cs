using CommonModels;

namespace Leetcode
{
    public class AddTwoNumbers_2
    {
        public MyLinkedListNode AddTwoNumbers(MyLinkedListNode l1, MyLinkedListNode l2)
        {
            int carry = 0;

            MyLinkedListNode root = new MyLinkedListNode(-1);
            MyLinkedListNode currentNode = root;
            while (l1 != null && l2 != null)
            {
                int sum = l1.Value + l2.Value + carry;
                carry = sum / 10;
                currentNode.Next = new MyLinkedListNode(sum % 10);
                currentNode = currentNode.Next;
                l1 = l1.Next;
                l2 = l2.Next;
            }

            if (l1 == null && l2 != null)
            {
                while (l2 != null)
                {
                    int sum = l2.Value + carry;
                    currentNode.Next = new MyLinkedListNode(sum % 10);
                    carry = sum / 10;
                    currentNode = currentNode.Next;
                    l2 = l2.Next;
                }
            }
            else if (l1 != null && l2 == null)
            {
                while (l1 != null)
                {
                    int sum = l1.Value + carry;
                    currentNode.Next = new MyLinkedListNode(sum % 10);
                    carry = sum / 10;
                    currentNode = currentNode.Next;
                    l1 = l1.Next;
                }
            }

            if (carry != 0)
                currentNode.Next = new MyLinkedListNode(carry);

            return root.Next;
        }
    }
}
