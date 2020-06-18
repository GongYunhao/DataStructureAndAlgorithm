using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class QueueUsingTwoStacksTest
    {
        [Fact]
        public void NormalTest()
        {
            QueueUsingTwoStacks<int> queue = new QueueUsingTwoStacks<int>();
            queue.AppendTail(1);
            Assert.Equal(1, queue.RemoveHead());
            queue.AppendTail(23);
            queue.AppendTail(35);
            queue.AppendTail(-2);
            Assert.Equal(23, queue.RemoveHead());
            queue.AppendTail(9);
            queue.AppendTail(13);
            Assert.Equal(35, queue.RemoveHead());
            Assert.Equal(-2, queue.RemoveHead());
            Assert.Equal(9, queue.RemoveHead());
            Assert.Equal(13, queue.RemoveHead());
            Assert.Throws<InvalidOperationException>(() => queue.RemoveHead());// 队列耗尽
        }

        [Fact]
        public void InvalidInput()
        {
            QueueUsingTwoStacks<object> queue = new QueueUsingTwoStacks<object>();
            Assert.Throws<ArgumentNullException>(() => queue.AppendTail(null));
        }
    }
}
