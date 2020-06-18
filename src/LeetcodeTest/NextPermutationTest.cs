using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class NextPermutationTest
    {
        [Fact]
        public void NormalTest1()
        {
            int[] result = { 1, 2, 3, 4 };
            new NextPermutation_31().NextPermutation(result);

            Assert.Equal(4, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(4, result[2]);
            Assert.Equal(3, result[3]);
        }

        [Fact]
        public void NormalTest2()
        {
            int[] result = { 1, 3, 4, 2 };
            new NextPermutation_31().NextPermutation(result);

            Assert.Equal(4, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(2, result[2]);
            Assert.Equal(3, result[3]);
        }

        [Fact]
        public void NormalTest3()
        {
            int[] result = { 1, 2, 3 };
            new NextPermutation_31().NextPermutation(result);

            Assert.Equal(3, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(3, result[1]);
            Assert.Equal(2, result[2]);
        }

        [Fact]
        public void NormalTest4()
        {
            int[] result = { 3, 2, 1 };
            new NextPermutation_31().NextPermutation(result);

            Assert.Equal(3, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        [Fact]
        public void NormalTest5()
        {
            int[] result = { 1, 1, 5 };
            var o = new NextPermutation_31();
            o.NextPermutation(result);
            Assert.Equal(3, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(5, result[1]);
            Assert.Equal(1, result[2]);

            o.NextPermutation(result);
            Assert.Equal(3, result.Length);
            Assert.Equal(5, result[0]);
            Assert.Equal(1, result[1]);
            Assert.Equal(1, result[2]);
        }

        [Fact]
        public void TestWithOneElementArray()
        {
            int[] result = { 5 };
            new NextPermutation_31().NextPermutation(result);

            Assert.Single(result);
            Assert.Equal(5, result[0]);
        }

        [Fact]
        public void InvaliInput()
        {
            Assert.Throws<ArgumentException>(() => new NextPermutation_31().NextPermutation(null));
            Assert.Throws<ArgumentException>(() => new NextPermutation_31().NextPermutation(new int[0]));
        }
    }
}
