using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public sealed class QueueUsingTwoStacks<T>
    {
        private readonly Stack<T> _stack1 = new Stack<T>();
        private readonly Stack<T> _stack2 = new Stack<T>();

        public void AppendTail(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Can't put null into queue");

            _stack1.Push(item);// 追加到队列尾部只需要在堆栈1上操作即可
        }

        public T RemoveHead()
        {
            if(_stack1.Count != 0 && _stack2.Count == 0)
                MoveAllItem(_stack1, _stack2);// 当堆栈2耗尽,且堆栈1中有内容时,将堆栈1的内容全部移动到堆栈2中

            if (_stack2.Count > 0)
                return _stack2.Pop();
            else 
                throw new InvalidOperationException("The queue is out of item");
        }

        private void MoveAllItem(Stack<T> source, Stack<T> destination)
        {
            while (source.Count != 0)
                destination.Push(source.Pop());
        }
    }
}
