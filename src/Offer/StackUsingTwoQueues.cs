using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class StackUsingTwoQueues<T>
    {
        // 任何时候都只能有一个队列中有值:
        // Push操作可以将item追加到有值的队列中(如果两个队列都没有值,默认追加到队列1中)
        private readonly Queue<T> _queue1 = new Queue<T>();
        private readonly Queue<T> _queue2 = new Queue<T>();

        public void Push(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Can't add null reference into stack");

            if (_queue2.Count == 0)
                _queue1.Enqueue(item);
            else
                _queue2.Enqueue(item);
        }

        public T Pop()
        {
            if (_queue1.Count != 0)
                return MoveAllItemsAndReturnLastOne(_queue1, _queue2);
            if (_queue2.Count != 0)
                return MoveAllItemsAndReturnLastOne(_queue2, _queue1);
            throw new InvalidOperationException("The stack is out of items");
        }

        private T MoveAllItemsAndReturnLastOne(Queue<T> source, Queue<T> destination)
        {
            while (source.Count > 1)
                destination.Enqueue(source.Dequeue());
            return source.Dequeue();
        }
    }
}
