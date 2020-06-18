using System;
using Xunit;

namespace Offer
{
    public class GetSumWithoutUsingCondition
    {
        public static int GetResult(int n)
        {
            return array[1].Sum(n);
        }

        private static A[] array = { new A(), new B() };

        private class A
        {
            internal virtual int Sum(int n)
            {
                return 0;
            }
        }

        private class B : A
        {
            internal override int Sum(int n)
            {
                return array[Convert.ToInt32(n > 1)].Sum(n - 1) + n;
            }
        }

        [Fact]
        private void Test()
        {
            Assert.Equal(15, GetResult(5));
        }
    }

    public class GetSumWithoutUsingConditionA
    {
        private static Func<int, int>[] array = { a => Terminator(a), a => Recursive(a) };

        public static int GetResult(int n)
        {
            return Recursive(n);
        }

        private static int Terminator(int n)
        {
            return 0;
        }

        private static int Recursive(int n)
        {
            return array[Convert.ToInt32(n > 1)](n - 1) + n;
        }

        [Fact]
        private void Test()
        {
            Assert.Equal(15, GetResult(5));
        }
    }
}
