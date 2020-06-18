using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class TheLongestSubstringTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(4, TheLongestSubstring.GetLength("arabcacfr"));
        }

        [Fact]
        public void EmptyString()
        {
            Assert.Equal(0, TheLongestSubstring.GetLength(""));
        }

        [Fact]
        public void StringWithOneChar()
        {
            Assert.Equal(1, TheLongestSubstring.GetLength("d"));
        }

        [Fact]
        public void StringWithNoDuplicateChar()
        {
            Assert.Equal(26, TheLongestSubstring.GetLength("abcdefghijklmnopqrstuvwxyz"));
        }

        [Fact]
        public void StringWithSameChar()
        {
            Assert.Equal(1, TheLongestSubstring.GetLength("ddddddddddddddddddddddd"));
        }

        [Fact]
        public void NullInput()
        {
            Assert.Throws<ArgumentNullException>(() => TheLongestSubstring.GetLength(null));
        }
    }
}
