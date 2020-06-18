using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class MultiplyStringsTest
    {
        [Fact]
        public void TestWithZero()
        {
            Assert.Equal("0", new MultiplyStrings_43().Multiply("0", "10"));
        }

        [Fact]
        public void NormalTest()
        {
            // 测试长度相等的两个乘数
            Assert.Equal("200", new MultiplyStrings_43().Multiply("20", "10"));// 最终数组前有0
            Assert.Equal("8100", new MultiplyStrings_43().Multiply("90", "90"));// 最终数组全部有效

            // 测试长度不等的两个乘数
            Assert.Equal("246", new MultiplyStrings_43().Multiply("123", "2"));
            Assert.Equal("1107", new MultiplyStrings_43().Multiply("123", "9"));

            // 测试较长的数字
            Assert.Equal("10000000000000000000000000000000000000000", new MultiplyStrings_43().Multiply("100000000000000000000", "100000000000000000000"));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new MultiplyStrings_43().Multiply(null, "10"));
            Assert.Throws<ArgumentException>(() => new MultiplyStrings_43().Multiply("10", null));
            Assert.Throws<ArgumentException>(() => new MultiplyStrings_43().Multiply("10", ""));
            Assert.Throws<ArgumentException>(() => new MultiplyStrings_43().Multiply("10", "  "));
        }
    }
}
