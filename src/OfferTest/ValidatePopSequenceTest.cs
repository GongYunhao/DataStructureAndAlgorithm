using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class ValidatePopSequenceTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.True(ValidatePopSequence.IsSequence(new[] { 1, 2, 3, 4, 5 }, new[] { 4, 5, 3, 2, 1 }));
            Assert.True(ValidatePopSequence.IsSequence(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }));

            Assert.False(ValidatePopSequence.IsSequence(new[] { 1, 2, 3, 4, 5 }, new[] { 4, 3, 5, 1, 2 }));
        }

        [Fact]
        public void ArraysWithDifferentLength()
        {
            Assert.False(ValidatePopSequence.IsSequence(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 3, 2, 1 }));
        }

        [Fact]
        public void NullReference()
        {
            Assert.Throws<ArgumentNullException>(() => ValidatePopSequence.IsSequence(null, null));
        }

        [Fact]
        public void ArraysWithDifferenceElements()
        {
            Assert.False(ValidatePopSequence.IsSequence(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 7, 3, 2, 1 }));
        }
    }
}
