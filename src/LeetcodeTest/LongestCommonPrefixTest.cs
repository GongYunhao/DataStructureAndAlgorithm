using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class LongestCommonPrefixTest
    {
        [Fact]
        public void TwoCommonPrefixChars()
        {
            Assert.Equal("fl", new LongestCommonPrefix_14().LongestCommonPrefix(new[] { "flower", "flow", "flight" }));
        }

        [Fact]
        public void OneCommonPrefixChars()
        {
            Assert.Equal("b", new LongestCommonPrefix_14().LongestCommonPrefix(new[] { "big", "bang", "building" }));
        }

        [Fact]
        public void NoCommonPrefixChars()
        {
            Assert.Equal(string.Empty, new LongestCommonPrefix_14().LongestCommonPrefix(new[] { "cig", "bang", "building" }));
            Assert.Equal(string.Empty, new LongestCommonPrefix_14().LongestCommonPrefix(new[] { "", "bang", "building" }));
        }


        [Fact]
        public void StringArrayContainsNoElement()
        {
            Assert.Equal(string.Empty, new LongestCommonPrefix_14().LongestCommonPrefix(new string[0]));
        }

        [Fact]
        public void StringArrayContainsOneElement()
        {
            Assert.Equal("big", new LongestCommonPrefix_14().LongestCommonPrefix(new[] { "big" }));
        }
    }
}
