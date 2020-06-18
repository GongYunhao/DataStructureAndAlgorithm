using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class LeastKNumsTest
    {
        [Fact]
        public void Test()
        {
            int[] result = LeastKNums.GetResult(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3);
            Assert.Equal(3, result.Length);
            Array.Sort(result);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void Test1()
        {
            int[] result = LeastKNums.GetResult(new[] { 9, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 3);
            Assert.Equal(3, result.Length);
            Array.Sort(result);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }
    }
}
