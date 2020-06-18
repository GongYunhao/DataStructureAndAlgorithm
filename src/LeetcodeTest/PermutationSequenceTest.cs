using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class PermutationSequenceTest
    {
        [Fact]
        public void TestWithOneDigits()
        {
            Assert.Equal("1", new PermutationSequence_60().GetPermutation(1, 1));
        }

        [Fact]
        public void TestWithTwoDigits()
        {
            Assert.Equal("12", new PermutationSequence_60().GetPermutation(2, 1));
            Assert.Equal("21", new PermutationSequence_60().GetPermutation(2, 2));
        }

        [Fact]
        public void TestWithThreeDigits()
        {
            Assert.Equal("123", new PermutationSequence_60().GetPermutation(3, 1));
            Assert.Equal("132", new PermutationSequence_60().GetPermutation(3, 2));
            Assert.Equal("213", new PermutationSequence_60().GetPermutation(3, 3));
            Assert.Equal("231", new PermutationSequence_60().GetPermutation(3, 4));
            Assert.Equal("312", new PermutationSequence_60().GetPermutation(3, 5));
            Assert.Equal("321", new PermutationSequence_60().GetPermutation(3, 6));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new PermutationSequence_60().GetPermutation(3, 7));
            Assert.Throws<ArgumentException>(() => new PermutationSequence_60().GetPermutation(3, 9));
        }
    }
}
