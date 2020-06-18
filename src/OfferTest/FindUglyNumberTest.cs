using Offer;
using Xunit;

namespace OfferTest
{
    public class FindUglyNumberTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, FindUglyNumber.GetByIndex(1));
            Assert.Equal(2, FindUglyNumber.GetByIndex(2));
            Assert.Equal(3, FindUglyNumber.GetByIndex(3));
            Assert.Equal(4, FindUglyNumber.GetByIndex(4));
            Assert.Equal(5, FindUglyNumber.GetByIndex(5));
            Assert.Equal(6, FindUglyNumber.GetByIndex(6));
            Assert.Equal(8, FindUglyNumber.GetByIndex(7));
        }

        [Fact]
        public void Experience()
        {
            FindUglyNumber.GetByIndex(1500);
        }
    }
}
