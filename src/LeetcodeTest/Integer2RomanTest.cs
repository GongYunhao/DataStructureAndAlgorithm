using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class Integer2RomanTest
    {
        [Fact]
        public void test()
        {
            Assert.Equal("MCMXCIV", new Integer2Roman_12().IntToRoman(1994));
        }
    }
}
