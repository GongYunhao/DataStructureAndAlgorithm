using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class PermutationsTest
    {
        [Fact]
        public void Test()
        {
            var result = new Permutations_46().Permute(new[] { 1, 2, 3 });

            Assert.Equal(6, result.Count);
            foreach (var l in result)
            {
                Assert.Equal(3, l.Count);
            }

            Assert.Contains(result, a => a[0] == 1 && a[1] == 2 && a[2] == 3);
            Assert.Contains(result, a => a[0] == 1 && a[1] == 3 && a[2] == 2);
            Assert.Contains(result, a => a[0] == 2 && a[1] == 1 && a[2] == 3);
            Assert.Contains(result, a => a[0] == 2 && a[1] == 3 && a[2] == 1);
            Assert.Contains(result, a => a[0] == 3 && a[1] == 2 && a[2] == 1);
            Assert.Contains(result, a => a[0] == 3 && a[1] == 1 && a[2] == 2);
        }

        [Fact]
        public void TestWithEmptyArray()
        {
            var result = new Permutations_46().Permute(new int[0]);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void TestWithOneElementArray()
        {
            var result = new Permutations_46().Permute(new[] { 1 });

            Assert.Equal(1, result.Count);
            foreach (var l in result)
            {
                Assert.Equal(1, l.Count);
            }

            Assert.Equal(1, result[0][0]);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new Permutations_46().Permute(null));
        }
    }
}
