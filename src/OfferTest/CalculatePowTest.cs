using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class CalculatePowTest
    {
        [Fact]
        public void FunctionTest()
        {
            Assert.Equal(4, CalculatePow.Power(2, 2));
            Assert.Equal(625, CalculatePow.Power(5, 4));

            Assert.Equal(0.25, CalculatePow.Power(2, -2));
            Assert.Equal(0.04, CalculatePow.Power(0.2, 2), 15);// 需要指定舍入精度(这也印证了double用==判断的隐藏问题)

            Assert.Equal(0, CalculatePow.Power(0, 3));
            Assert.Equal(1, CalculatePow.Power(3, 0));

            Assert.Equal(-8, CalculatePow.Power(-2, 3));
            Assert.Equal(16, CalculatePow.Power(-2, 4));
        }

        [Fact]
        public void ExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => CalculatePow.Power(0, 0));
            Assert.Throws<ArgumentException>(() => CalculatePow.Power(0, -2));
        }

        [Fact]
        public void BorderTest()
        {
            Assert.Equal(double.PositiveInfinity, CalculatePow.Power(2, Int32.MaxValue));
            Assert.Equal(0, CalculatePow.Power(2, Int32.MinValue),15);
        }
    }
}
