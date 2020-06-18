using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class StackUsingTwoQueuesTest
    {
        [Fact]
        public void NormalTest()
        {
            StackUsingTwoQueues<int> stack = new StackUsingTwoQueues<int>();
            stack.Push(1);
            Assert.Equal(1, stack.Pop());

            Assert.Throws<InvalidOperationException>(() => stack.Pop());

            stack.Push(50);
            stack.Push(100);
            Assert.Equal(100, stack.Pop());
            stack.Push(4993);
            Assert.Equal(4993, stack.Pop());
            stack.Push(3);
            Assert.Equal(3, stack.Pop());
            Assert.Equal(50, stack.Pop());
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void InvaliInput()
        {
            StackUsingTwoQueues<object> stack = new StackUsingTwoQueues<object>();
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }
    }
}
