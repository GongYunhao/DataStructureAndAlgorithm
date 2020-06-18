using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class CountAndSayTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("1", new CountAndSay_38().CountAndSay(1));
            Assert.Equal("11", new CountAndSay_38().CountAndSay(2));
            Assert.Equal("21", new CountAndSay_38().CountAndSay(3));
            Assert.Equal("1211", new CountAndSay_38().CountAndSay(4));
            Assert.Equal("111221", new CountAndSay_38().CountAndSay(5));
        }

        [Fact]
        public void InvalidTest()
        {
            Assert.Throws<ArgumentException>(() => new CountAndSay_38().CountAndSay(0));
            Assert.Throws<ArgumentException>(() => new CountAndSay_38().CountAndSay(31));
        }
    }
}
