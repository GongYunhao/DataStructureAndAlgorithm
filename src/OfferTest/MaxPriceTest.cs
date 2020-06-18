using Offer;
using Xunit;

namespace OfferTest
{
    public class MaxPriceTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(53, MaxPrice.GetResult(new[,] { { 1, 10, 3, 8 }, { 12, 2, 9, 6 }, { 5, 7, 4, 11 }, { 3, 7, 16, 5 } }));
        }

        [Fact]
        public void TestWithOneRowMatrix()
        {
            Assert.Equal(22, MaxPrice.GetResult(new[,] { { 1, 10, 3, 8 } }));
        }

        [Fact]
        public void TestWithOneElementMatrix()
        {
            Assert.Equal(12, MaxPrice.GetResult(new[,] { { 12 } }));
        }
    }
}
