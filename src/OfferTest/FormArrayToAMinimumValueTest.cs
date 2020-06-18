using Offer;
using Xunit;

namespace OfferTest
{
    public class FormArrayToAMinimumValueTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("321323", FormArrayToAMinimumValue.Form(new[] { "32", "3", "321" }));
        }
    }
}
