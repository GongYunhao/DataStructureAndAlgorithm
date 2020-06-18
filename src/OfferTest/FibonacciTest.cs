using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class FibonacciUsingMatrixTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(0, FibonacciUsingMatrix.Calculate(0));
            Assert.Equal(1, FibonacciUsingMatrix.Calculate(1));
            Assert.Equal(1, FibonacciUsingMatrix.Calculate(2));
            Assert.Equal(2, FibonacciUsingMatrix.Calculate(3));
            Assert.Equal(3, FibonacciUsingMatrix.Calculate(4));
            Assert.Equal(5, FibonacciUsingMatrix.Calculate(5));
            Assert.Equal(8, FibonacciUsingMatrix.Calculate(6));
            Assert.Equal(13, FibonacciUsingMatrix.Calculate(7));
            Assert.Equal(21, FibonacciUsingMatrix.Calculate(8));
            Assert.Equal(34, FibonacciUsingMatrix.Calculate(9));
            Assert.Equal(55, FibonacciUsingMatrix.Calculate(10));
            FibonacciUsingMatrix.Calculate(1000);
        }
    }

    public class FibonacciTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(0, Fibonacci.Calculate(0));
            Assert.Equal(1, Fibonacci.Calculate(1));
            Assert.Equal(1, Fibonacci.Calculate(2));
            Assert.Equal(2, Fibonacci.Calculate(3));
            Assert.Equal(3, Fibonacci.Calculate(4));
            Assert.Equal(5, Fibonacci.Calculate(5));
            Assert.Equal(8, Fibonacci.Calculate(6));
            Assert.Equal(13, Fibonacci.Calculate(7));
            Assert.Equal(21, Fibonacci.Calculate(8));
            Assert.Equal(34, Fibonacci.Calculate(9));
            Assert.Equal(55, Fibonacci.Calculate(10));
            Fibonacci.Calculate(1000);
        }
    }
}
