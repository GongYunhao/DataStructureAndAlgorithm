using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class LongestPalindromicSubstringTest
    {
        [Fact]
        public void test()
        {
            Assert.Equal("aba", new LongestPalindromicSubstring_5().LongestPalindrome("babad"));
        }
    }
}
