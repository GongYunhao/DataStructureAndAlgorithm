using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class Search2DMatrixTest
    {
        [Fact]
        public void Test()
        {
            int[][] matrix = { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 50 } };
            Assert.True(new Search2DMatrix_74().SearchMatrix(matrix, 3));
        }

        [Fact]
        public void Test1()
        {
            int[][] matrix = { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 50 } };
            Assert.False(new Search2DMatrix_74().SearchMatrix(matrix, 13));
        }
    }
}
