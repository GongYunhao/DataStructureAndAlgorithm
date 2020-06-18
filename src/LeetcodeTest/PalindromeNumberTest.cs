using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class PalindromeNumberTest
    {
        [Fact]
        public void test()
        {
            Assert.True(new PalindromeNumber_9().IsPalindrome(121));
        }
    }
}
