using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class RemoveDuplicatesFromSortedArrayTest
    {
        [Fact]
        public void NormalTest()
        {
            int[] array = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Assert.Equal(5, new RemoveDuplicatesFromSortedArray_26().RemoveDuplicates(array));
            Assert.Equal(0, array[0]);
            Assert.Equal(1, array[1]);
            Assert.Equal(2, array[2]);
            Assert.Equal(3, array[3]);
            Assert.Equal(4, array[4]);
        }

        [Fact]
        public void NormalTest1()
        {
            int[] array = { 1, 1, 2 };
            Assert.Equal(2, new RemoveDuplicatesFromSortedArray_26().RemoveDuplicates(array));
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void SameElementArray()
        {
            int[] array = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Assert.Equal(1, new RemoveDuplicatesFromSortedArray_26().RemoveDuplicates(array));
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void OneElementArray()
        {
            int[] array = { 20 };
            Assert.Equal(1, new RemoveDuplicatesFromSortedArray_26().RemoveDuplicates(array));
            Assert.Equal(20, array[0]);
        }

        [Fact]
        public void EmptyArray()
        {
            Assert.Equal(0, new RemoveDuplicatesFromSortedArray_26().RemoveDuplicates(new int[0]));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveDuplicatesFromSortedArray_26().RemoveDuplicates(null));
        }
    }
}
