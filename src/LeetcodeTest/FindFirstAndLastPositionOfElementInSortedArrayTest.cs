using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class FindFirstAndLastPositionOfElementInSortedArrayTest
    {
        [Fact]
        public void NormalTest()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 8);
            Assert.Equal(3, result[0]);
            Assert.Equal(4, result[1]);

            int[] result1 =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 10 }, 7);
            Assert.Equal(1, result1[0]);
            Assert.Equal(8, result1[1]);

            int[] result2 =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 10 }, 8);
            Assert.Equal(9, result2[0]);
            Assert.Equal(10, result2[1]);

            int[] result3 =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 10 }, 5);
            Assert.Equal(0, result3[0]);
            Assert.Equal(0, result3[1]);
        }

        [Fact]
        public void NumsArrayContainsOnlyOneElement()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5 }, 5);

            Assert.Equal(0, result[0]);
            Assert.Equal(0, result[1]);
        }

        [Fact]
        public void NumsArrayContainsSameElement()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 5, 5, 5, 5, 5, 5, 5 }, 5);

            Assert.Equal(0, result[0]);
            Assert.Equal(7, result[1]);
        }

        [Fact]
        public void TestNotFound_TargetBetweenMaxAndMinValue()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 6);

            Assert.Equal(-1, result[0]);
            Assert.Equal(-1, result[1]);
        }

        [Fact]
        public void TestNotFound_TargetOutOfRange()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 11);

            Assert.Equal(-1, result[0]);
            Assert.Equal(-1, result[1]);
        }

        [Fact]
        public void EmptyArray()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new int[0], 0);

            Assert.Equal(-1, result[0]);
            Assert.Equal(-1, result[1]);
        }

        [Fact]
        public void BugInLeetcode()
        {
            int[] result =
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(new[] { 1, 2, 3 }, 3);

            Assert.Equal(2, result[0]);
            Assert.Equal(2, result[1]);
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentException>(() =>
                new FindFirstAndLastPositionOfElementInSortedArray_34().SearchRange(null, 6));
        }
    }
}
