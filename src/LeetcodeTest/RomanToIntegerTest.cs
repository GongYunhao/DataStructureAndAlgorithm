using System;
using System.Collections.Generic;
using System.Text;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class RomanToIntegerTest
    {
        [Fact]
        public void test()
        {
            Assert.Equal(8, new RomanToInteger_13().RomanToInt("VIII"));
            Assert.Equal(4, new RomanToInteger_13().RomanToInt("IV"));
            Assert.Equal(1994, new RomanToInteger_13().RomanToInt("MCMXCIV"));
        }

        [Fact]
        public void SpecialInput()
        {
            Assert.Equal(0, new RomanToInteger_13().RomanToInt(string.Empty));
            Assert.Equal(0, new RomanToInteger_13().RomanToInt(null));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentException>(()=>new RomanToInteger_13().RomanToInt("dd"));
        }
    }
}
