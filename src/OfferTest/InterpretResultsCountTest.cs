using Offer;
using Xunit;

namespace OfferTest
{
    public class InterpretResultsCountTest
    {
        [Fact]
        public void ExampleOnBook()
        {
            Assert.Equal(5, InterpretResultsCount.Calculate(12258));
        }

        [Fact]
        public void BoundaryCondition()
        {
            Assert.Equal(1, InterpretResultsCount.Calculate(0));
            Assert.Equal(2, InterpretResultsCount.Calculate(10));
            Assert.Equal(2, InterpretResultsCount.Calculate(25));
            Assert.Equal(1, InterpretResultsCount.Calculate(26));
        }
    }
}
