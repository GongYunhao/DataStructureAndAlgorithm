using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class RemoveElementTest
    {
        [Fact]
        public void NormalTest()
        {
            int[] array = { 3, 2, 2, 3 };
            Assert.Equal(2, new RemoveElement_27().RemoveElement(array, 3));
            Assert.Equal(2, array[0]);
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void NormalTest1()
        {
            int[] array = { 0, 1, 2, 2, 3, 0, 4, 2 };
            Assert.Equal(5, new RemoveElement_27().RemoveElement(array, 2));
            Assert.Equal(0, array[0]);
            Assert.Equal(1, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(0, array[3]);
            Assert.Equal(4, array[4]);
        }

        [Fact]
        public void ArrayWithSameElement()
        {
            int[] array = { 2, 2, 2, 2, 2, 2, 2, 2 };
            Assert.Equal(0, new RemoveElement_27().RemoveElement(array, 2));
        }

        [Fact]
        public void ArrayWithSameElementButRemoveNone()
        {
            int[] array = { 2, 2, 2, 2, 2, 2, 2, 2 };
            Assert.Equal(8, new RemoveElement_27().RemoveElement(array, 3));
        }

        [Fact]
        public void SpecialTest()
        {
            int[] array = { };
            Assert.Equal(0, new RemoveElement_27().RemoveElement(array, 2));

            int[] array1 = { 1 };
            Assert.Equal(0, new RemoveElement_27().RemoveElement(array1, 1));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveElement_27().RemoveElement(null, 2));
        }

        [Fact]
        public void BugFoundInLeetcode()
        {
            int[] array = { 2 };
            Assert.Equal(1, new RemoveElement_27().RemoveElement(array, 3));
        }
    }
}
