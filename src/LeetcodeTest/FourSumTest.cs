using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class FourSumTest
    {
        [Fact]
        public void InputNormalArray_GetThreeLists()
        {
            int[] array = { 1, 0, -1, 0, -2, 2 };
            var result = new FourSum_18().FourSum(array, 0);

            Assert.Equal(3, result.Count);
            Assert.True(result[0].ContainsSameElement(new[] { -2, -1, 1, 2 }));
            Assert.True(result[1].ContainsSameElement(new[] { -2, 0, 0, 2 }));
            Assert.True(result[2].ContainsSameElement(new[] { -1, 0, 0, 1 }));
        }

        [Fact]
        public void InputAllZeroArray_GetOneLists()
        {
            int[] array = { 0, 0, 0, 0, 0, 0, 0, 0 };
            var result = new FourSum_18().FourSum(array, 0);

            Assert.Equal(1, result.Count);
            Assert.True(result[0].ContainsSameElement(new[] { 0, 0, 0, 0 }));
        }

        [Fact]
        public void InputAllZeroArray_GetEmptyList()
        {
            int[] array = { 0, 0, 0, 0, 0, 0, 0, 0 };
            var result = new FourSum_18().FourSum(array, 1);

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void InputEmptyArray_GetEmptyList()
        {
            int[] array = { };
            var result = new FourSum_18().FourSum(array, 1);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void InputNotEnoughLengthArray_GetEmptyList()
        {
            int[] array = { 1, 2, 3 };
            var result = new FourSum_18().FourSum(array, 3);
            Assert.Equal(0, result.Count);
        }
    }
}
