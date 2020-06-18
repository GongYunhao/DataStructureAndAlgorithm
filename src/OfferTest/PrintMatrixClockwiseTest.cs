using Offer;
using Xunit;

namespace OfferTest
{
    public class PrintMatrixClockwiseTest
    {
        [Fact]
        public void Matrix_4x4()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            Assert.Equal("1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10", PrintMatrixClockwise.GetTotalResult(matrix));
        }

        [Fact]
        public void Matrix_1x4()
        {
            int[,] matrix = { { 1, 2, 3, 4 } };
            Assert.Equal("1,2,3,4", PrintMatrixClockwise.GetTotalResult(matrix));
        }

        [Fact]
        public void Matrix_2x4()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            Assert.Equal("1,2,3,4,8,7,6,5", PrintMatrixClockwise.GetTotalResult(matrix));
        }

        [Fact]
        public void Matrix_3x4()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            Assert.Equal("1,2,3,4,8,12,11,10,9,5,6,7", PrintMatrixClockwise.GetTotalResult(matrix));
        }

        [Fact]
        public void Matrix_4x3()
        {
            int[,] matrix = { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 10, 11 }, { 13, 14, 15 } };
            Assert.Equal("1,2,3,7,11,15,14,13,9,5,6,10", PrintMatrixClockwise.GetTotalResult(matrix));
        }

        [Fact]
        public void Matrix_1x1()
        {
            int[,] matrix = { { 1 } };
            Assert.Equal("1", PrintMatrixClockwise.GetTotalResult(matrix));
        }

        [Fact]
        public void Matrix_4x1()
        {
            int[,] matrix = { { 1 }, { 2 }, { 3 }, { 4 } };
            Assert.Equal("1,2,3,4", PrintMatrixClockwise.GetTotalResult(matrix));
        }
    }
}
