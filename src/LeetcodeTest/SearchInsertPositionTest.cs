using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class SearchInsertPositionTest
    {
        [Fact]
        public void ElementInTheArray()
        {
            Assert.Equal(0, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 1));
            Assert.Equal(4, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 12));
            Assert.Equal(9, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 11254));
        }

        [Fact]
        public void ElementNotInTheArray()
        {
            Assert.Equal(0, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 0));
            Assert.Equal(4, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 11));
            Assert.Equal(9, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 11253));
            Assert.Equal(10, new SearchInsertPosition_35().SearchInsert(new[] { 1, 5, 9, 10, 12, 45, 78, 96, 332, 11254 }, 11255));
        }

        [Fact]
        public void ArrayWithOnlyOneElement()
        {
            Assert.Equal(0, new SearchInsertPosition_35().SearchInsert(new[] { 10 }, 10));

            Assert.Equal(0, new SearchInsertPosition_35().SearchInsert(new[] { 10 }, 0));
            Assert.Equal(1, new SearchInsertPosition_35().SearchInsert(new[] { 10 }, 11));
        }

        [Fact]
        public void ArrayWithNoElement()
        {
            Assert.Equal(0, new SearchInsertPosition_35().SearchInsert(new int[0], 10));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new SearchInsertPosition_35().SearchInsert(null, 10));
        }
    }
}
