namespace CommonModels
{
    public sealed class BinaryTreeNode<T>
    {
        private BinaryTreeNode<T> _left;
        private BinaryTreeNode<T> _right;

        public BinaryTreeNode()
        {

        }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public BinaryTreeNode<T> Left
        {
            get => _left;
            set
            {
                _left = value;
                if (_left != null)
                    _left.Parent = this;
            }
        }
        public BinaryTreeNode<T> Right
        {
            get => _right;
            set
            {
                _right = value;
                if (_right != null)
                    _right.Parent = this;
            }
        }
        public BinaryTreeNode<T> Parent { get; private set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
