using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class RotatedArrayTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(1, RotatedArray.FindMin(new[] { 4, 5, 6, 7, 1, 2, 3 }));
            Assert.Equal(1, RotatedArray.FindMin(new[] { 3, 3, 6, 7, 1, 2, 3 }));

            Assert.Equal(0, RotatedArray.FindMin(new[] { 1, 1, 1, 1, 0, 1 }));
            Assert.Equal(1, RotatedArray.FindMin(new[] { 1 }));
            Assert.Equal(1, RotatedArray.FindMin(new[] { 1, 2, 3, 4, 5, 6 }));
            Assert.Equal(1, RotatedArray.FindMin(new[] { 1, 1, 1, 1, 1, 1 }));
        }

        [Fact]
        public void ExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => RotatedArray.FindMin(new int[0]));
            Assert.Throws<ArgumentException>(() => RotatedArray.FindMin(null));
        }
    }
}
