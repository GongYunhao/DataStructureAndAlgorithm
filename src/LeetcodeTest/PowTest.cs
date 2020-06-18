using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class PowTest
    {
        [Fact]
        public void TestWithExponentAboveZero()
        {
            Assert.Equal(2, new Pow_50().MyPow(2, 1), 15);
            Assert.Equal(4, new Pow_50().MyPow(2, 2), 15);
            Assert.Equal(8, new Pow_50().MyPow(2, 3), 15);
            Assert.Equal(16, new Pow_50().MyPow(2, 4), 15);
            Assert.Equal(65536, new Pow_50().MyPow(2, 16), 15);

            Assert.Equal(6.25, new Pow_50().MyPow(2.5, 2), 15);
            Assert.Equal(0.04, new Pow_50().MyPow(0.2, 2), 15);

            Assert.Equal(-2, new Pow_50().MyPow(-2, 1), 15);
            Assert.Equal(4, new Pow_50().MyPow(-2, 2), 15);
            Assert.Equal(-8, new Pow_50().MyPow(-2, 3), 15);
            Assert.Equal(16, new Pow_50().MyPow(-2, 4), 15);
            Assert.Equal(65536, new Pow_50().MyPow(-2, 16), 15);
        }

        [Fact]
        public void TestWithExponentUnderZero()
        {
            Assert.Equal(0.5, new Pow_50().MyPow(2, -1), 15);
            Assert.Equal(0.25, new Pow_50().MyPow(2, -2), 15);
            Assert.Equal(0.125, new Pow_50().MyPow(2, -3), 15);

            Assert.Equal(-0.5, new Pow_50().MyPow(-2, -1), 15);
            Assert.Equal(0.25, new Pow_50().MyPow(-2, -2), 15);
            Assert.Equal(-0.125, new Pow_50().MyPow(-2, -3), 15);
        }

        [Fact]
        public void TestWithExponentZero()
        {
            Assert.Equal(1, new Pow_50().MyPow(2, 0), 15);
            Assert.Equal(1, new Pow_50().MyPow(-22, 0), 15);
        }

        [Fact]
        public void TestWithSpecialInput()
        {
            Assert.Equal(Math.Pow(2, int.MinValue), new Pow_50().MyPow(2, Int32.MinValue), 15);
            Assert.Equal(Math.Pow(2, int.MaxValue), new Pow_50().MyPow(2, Int32.MaxValue), 15);

            // 由于指数太大,结果会无限趋近于0,即使指定15位的double精度也不能区分,所以需要以-1为底的情况,通过正负判断
            Assert.Equal(Math.Pow(-1, int.MinValue), new Pow_50().MyPow(-1, Int32.MinValue), 15);
            Assert.Equal(Math.Pow(-1, int.MaxValue), new Pow_50().MyPow(-1, Int32.MaxValue), 15);
        }
    }
}
