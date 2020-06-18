namespace CommonModels
{
    public class MyLinkedListNode
    {
        public MyLinkedListNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public MyLinkedListNode Next { get; set; }
    }

    public class ComplexLinkedListNode
    {
        public ComplexLinkedListNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public ComplexLinkedListNode Sibling { get; set; }

        public ComplexLinkedListNode Next { get; set; }
    }
}
