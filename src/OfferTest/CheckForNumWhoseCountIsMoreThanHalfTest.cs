using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class CheckForNumWhoseCountIsMoreThanHalfTest
    {
        [Fact]
        public void ArrayWithOneElement()
        {
            Assert.Equal(1, CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 1 }));
        }

        [Fact]
        public void ArrayWithTwoElements()
        {
            Assert.Equal(1, CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 1, 1 }));
        }

        [Fact]
        public void ArrayWithMultipleElements()
        {
            Assert.Equal(2, CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 1, 2, 3, 2, 2, 2, 5, 4, 2 }));
            Assert.Equal(2, CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 2, 1, 2, 2, 2, 2, 5, 4, 2, 5 }));
            Assert.Equal(2, CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 1, 2, 3, 2, 2, 2, 2, 5, 4, 2, 10 }));
            Assert.Equal(2, CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 2, 3, 2, 2, 50, 2, 2, 1, 2, 5, 4, 2, 10 }));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => CheckForNumWhoseCountIsMoreThanHalf.GetResult(null));
            Assert.Throws<ArgumentException>(() => CheckForNumWhoseCountIsMoreThanHalf.GetResult(new int[0]));
            Assert.Throws<ArgumentException>(() => CheckForNumWhoseCountIsMoreThanHalf.GetResult(new[] { 10, 13, 15, 16, 14, 10 }));
        }
    }
}
