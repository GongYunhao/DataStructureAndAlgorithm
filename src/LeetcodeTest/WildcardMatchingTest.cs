using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class WildcardMatchingTest
    {
        [Fact]
        public void Test()
        {
            Assert.False(new WildcardMatching_44().IsMatch("aa", "a"));
            Assert.True(new WildcardMatching_44().IsMatch("aa", "aa"));
            Assert.True(new WildcardMatching_44().IsMatch("aa", "*"));
            Assert.True(new WildcardMatching_44().IsMatch("aa", "?a"));

            Assert.False(new WildcardMatching_44().IsMatch("cb", "?a"));
            Assert.True(new WildcardMatching_44().IsMatch("adceb", "*a*b"));

            Assert.False(new WildcardMatching_44().IsMatch("acdcb", "a*c?b"));
        }

        [Fact]
        public void SpecialInput()
        {
            Assert.True(new WildcardMatching_44().IsMatch("", ""));
            Assert.True(new WildcardMatching_44().IsMatch("", "*"));

            Assert.True(new WildcardMatching_44().IsMatch("a", "?"));
            Assert.False(new WildcardMatching_44().IsMatch("ibe", ""));
        }

        [Fact]
        public void BugFoundInLeetcode()
        {
            Assert.True(new WildcardMatching_44().IsMatch("ho", "ho**"));
        }

        [Fact]
        public void Bug2FoundInLeetcode()
        {
            Assert.False(new WildcardMatching_44().IsMatch("aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba", "a***********b"));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new WildcardMatching_44().IsMatch(null, "*"));
            Assert.Throws<ArgumentNullException>(() => new WildcardMatching_44().IsMatch("a", null));
        }
    }
}
