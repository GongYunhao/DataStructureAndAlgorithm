using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class CuttingRodTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(0, CuttingRod.GetMaxResultUsingDP(0));
            Assert.Equal(0, CuttingRod.GetMaxResultUsingDP(1));
            Assert.Equal(1, CuttingRod.GetMaxResultUsingDP(2));
            Assert.Equal(2, CuttingRod.GetMaxResultUsingDP(3));
            Assert.Equal(4, CuttingRod.GetMaxResultUsingDP(4));
            Assert.Equal(18, CuttingRod.GetMaxResultUsingDP(8));
        }
    }
}
