using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class LongestSubstringWithoutRepeatingCharactersTest
    {
        [Fact]
        public void test()
        {
            Assert.Equal(2, new LongestSubstringWithoutRepeatingCharacters_3().LengthOfLongestSubstring("aab"));
            Assert.Equal(5, new LongestSubstringWithoutRepeatingCharacters_3().LengthOfLongestSubstring("tmmxust"));
        }
    }
}
