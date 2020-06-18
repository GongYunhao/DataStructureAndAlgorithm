using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class FindPathInMatrixTest
    {
        [Fact]
        public void NormalTest()
        {
            char[,] matrix =
            {
                {'a','b','t','g'},
                {'c','f','c','s'},
                {'j','d','e','h'}
            };

            Assert.True(FindPathInMatrix.HasPath(matrix, "bfce"));
            Assert.True(FindPathInMatrix.HasPath(matrix, "cfce"));
            Assert.False(FindPathInMatrix.HasPath(matrix, "bfcg"));
            Assert.False(FindPathInMatrix.HasPath(matrix, " "));
            Assert.False(FindPathInMatrix.HasPath(matrix, "cccc"));
            Assert.False(FindPathInMatrix.HasPath(matrix, "cfcf"));
            Assert.False(FindPathInMatrix.HasPath(matrix, "abac"));
            Assert.False(FindPathInMatrix.HasPath(matrix, "btgt"));

            char[,] matrix1 =
            {
                {'a','b','t','g','c','f','c','s','j','d','e','h'}
            };
            Assert.True(FindPathInMatrix.HasPath(matrix1, "cfcs"));
            Assert.False(FindPathInMatrix.HasPath(matrix1, "csjs"));

            char[,] matrix2 =
            {
                {'a','a','a','a','a','a','a','a','a','a','a','a'}
            };
            Assert.True(FindPathInMatrix.HasPath(matrix2, "aaaa"));
            Assert.False(FindPathInMatrix.HasPath(matrix2, "csjs"));
            Assert.False(FindPathInMatrix.HasPath(matrix2, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        }

        [Fact]
        public void ExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => FindPathInMatrix.HasPath(null, "sss"));
            Assert.Throws<ArgumentException>(() => FindPathInMatrix.HasPath(new char[4, 3], null));

            char[,] matrix =
            {
                {'a','b','t','g'},
                {'c','f','c','s'},
                {'j','d','e','h'}
            };
            Assert.Throws<ArgumentException>(() => FindPathInMatrix.HasPath(matrix, string.Empty));
        }
    }
}
