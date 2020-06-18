using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class FindNumInMatrixTest
    {
        private readonly int[] matrix = { 1, 2, 8, 9, 2, 4, 9, 12, 4, 7, 10, 13, 6, 8, 11, 15 };

        [Fact]
        public void Test1()
        {
            // 测试四个角上的数字
            Assert.True(FindNumInMatrix.Execute(matrix, 4, 4, 1));
            Assert.True(FindNumInMatrix.Execute(matrix, 4, 4, 6));
            Assert.True(FindNumInMatrix.Execute(matrix, 4, 4, 9));
            Assert.True(FindNumInMatrix.Execute(matrix, 4, 4, 15));
            // 随机挑选几个位于中间的数字来测试
            Assert.True(FindNumInMatrix.Execute(matrix, 4, 4, 7));
            Assert.True(FindNumInMatrix.Execute(matrix, 4, 4, 13));

            // 测试范围外的数字
            Assert.False(FindNumInMatrix.Execute(matrix, 4, 4, 19));
            Assert.False(FindNumInMatrix.Execute(matrix, 4, 4, -1));

            // 测试范围中,但是不在矩阵内的数字
            Assert.False(FindNumInMatrix.Execute(matrix, 4, 4, 3));

            //测试空指针
            Assert.Throws<NullReferenceException>(() => FindNumInMatrix.Execute(null, 4, 4, 3));
        }
    }
}
