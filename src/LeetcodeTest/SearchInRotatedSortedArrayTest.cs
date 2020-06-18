using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class SearchInRotatedSortedArrayTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(4, new SearchInRotatedSortedArray_33().Search(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
            Assert.Equal(-1, new SearchInRotatedSortedArray_33().Search(new[] { 4, 5, 6, 7, 0, 1, 2 }, 8));

            Assert.Equal(5, new SearchInRotatedSortedArray_33().Search(new[] { 3, 4, 5, 6, 7, 0, 1, 2 }, 0));
            Assert.Equal(-1, new SearchInRotatedSortedArray_33().Search(new[] { 4, 5, 6, 7, 0, 1, 2 }, 8));
        }

        [Fact]
        public void Test_NoRotate()
        {
            Assert.Equal(0, new SearchInRotatedSortedArray_33().Search(new[] { 0, 1, 2, 4, 5, 6, 7 }, 0));
            Assert.Equal(6, new SearchInRotatedSortedArray_33().Search(new[] { 0, 1, 2, 4, 5, 6, 7 }, 7));
            Assert.Equal(-1, new SearchInRotatedSortedArray_33().Search(new[] { 0, 1, 2, 4, 5, 6, 7 }, 3));
        }

        [Fact]
        public void Test_ArrayContainsOnlyOneElement()
        {
            Assert.Equal(0, new SearchInRotatedSortedArray_33().Search(new[] { 100 }, 100));
            Assert.Equal(-1, new SearchInRotatedSortedArray_33().Search(new[] { 100 }, 12));
        }

        [Fact]
        public void Test_EmptyArray()
        {
            Assert.Equal(-1, new SearchInRotatedSortedArray_33().Search(new int[0], 100));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new SearchInRotatedSortedArray_33().Search(null, 100));
        }
    }
}
