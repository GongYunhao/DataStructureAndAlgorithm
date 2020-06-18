using Offer;
using Xunit;

namespace OfferTest
{
    public class GetMissingNumTest
    {
        [Fact]
        public void TestWithMissingElementAtFirstSlot()
        {
            Assert.Equal(0, GetMissingNum.GetResult(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }

        [Fact]
        public void TestWithMissingElementAtLastSlot()
        {
            Assert.Equal(10, GetMissingNum.GetResult(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 }));
        }

        [Fact]
        public void TestWithMissingElementAtMiddle()
        {
            Assert.Equal(5, GetMissingNum.GetResult(new[] { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10, 11 }));
        }

        [Fact]
        public void TestWithOnlyOneElement()
        {
            Assert.Equal(0, GetMissingNum.GetResult(new int[0]));
        }
    }
}
