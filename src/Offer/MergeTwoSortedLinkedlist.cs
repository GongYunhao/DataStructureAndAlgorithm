using CommonModels;

namespace Offer
{
    public class MergeTwoSortedLinkedlist
    {
        public static MyLinkedListNode Merge(MyLinkedListNode head1, MyLinkedListNode head2)
        {
            return MergeRecursively(head1, head2);
            //return MergeUsingWhile(head1, head2);
        }

        // 这种写法利用了递归,十分简洁,问题在于程序栈有溢出的风险,每次递归只能计算出一个节点,效率不一定很高
        private static MyLinkedListNode MergeRecursively(MyLinkedListNode head1, MyLinkedListNode head2)
        {
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;

            MyLinkedListNode head = null;

            if (head1.Value > head2.Value)
            {
                head = head2;
                head.Next = MergeRecursively(head1, head2.Next);
            }
            else
            {
                head = head1;
                head.Next = MergeRecursively(head1.Next, head2);
            }

            return head;
        }

        // 这种写法利用了while循环,程序栈没有溢出风险,问题在于写法比较繁琐,要多次判断两个链表头节点的大小
        private static MyLinkedListNode MergeUsingWhile(MyLinkedListNode head1, MyLinkedListNode head2)
        {
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;

            // head节点为null,而且要从两个链表中取一个来作为头节点,这次比对不能避免
            MyLinkedListNode head = null;
            if (head1.Value > head2.Value)
            {
                head = head2;
                head2 = head2.Next;
            }
            else
            {
                head = head1;
                head1 = head1.Next;
            }

            MyLinkedListNode current = head;
            while (head1 != null && head2 != null)
            {
                if (head1.Value > head2.Value)
                {
                    current.Next = head2;
                    current = head2;
                    head2 = head2.Next;
                }
                else
                {
                    current.Next = head1;
                    current = head1;
                    head1 = head1.Next;
                }
            }

            current.Next = head1 == null ? head2 : head1;

            return head;
        }
    }
}
