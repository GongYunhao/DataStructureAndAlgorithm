using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class RotateImageTest
    {
        // 测试只包含一个元素的矩阵
        [Fact]
        public void TestWithOneElementImage()
        {
            int[,] image = { { 5 } };
            new RotateImage_48().Rotate(image);

            Assert.Equal(5, image[0, 0]);
        }

        // 测试当矩阵长宽为奇数时，程序是否正确
        // 由于分割方式在奇数和偶数不同，所以都要单独测试
        [Fact]
        public void TestWithSingleImageLength()
        {
            int[,] image =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            new RotateImage_48().Rotate(image);

            Assert.Equal(7, image[0, 0]);
            Assert.Equal(4, image[0, 1]);
            Assert.Equal(1, image[0, 2]);
            Assert.Equal(8, image[1, 0]);
            Assert.Equal(5, image[1, 1]);
            Assert.Equal(2, image[1, 2]);
            Assert.Equal(9, image[2, 0]);
            Assert.Equal(6, image[2, 1]);
            Assert.Equal(3, image[2, 2]);
        }

        // 测试当矩阵长宽为偶数时，程序是否正确
        [Fact]
        public void TestWithDoubleImageLength()
        {
            int[,] image =
            {
                { 5, 1, 9, 11},
                { 2, 4, 8, 10},
                {13, 3, 6, 7},
                {15, 14, 12, 16}
            };
            new RotateImage_48().Rotate(image);

            Assert.Equal(15, image[0, 0]);
            Assert.Equal(13, image[0, 1]);
            Assert.Equal(2, image[0, 2]);
            Assert.Equal(5, image[0, 3]);
            Assert.Equal(14, image[1, 0]);
            Assert.Equal(3, image[1, 1]);
            Assert.Equal(4, image[1, 2]);
            Assert.Equal(1, image[1, 3]);
            Assert.Equal(12, image[2, 0]);
            Assert.Equal(6, image[2, 1]);
            Assert.Equal(8, image[2, 2]);
            Assert.Equal(9, image[2, 3]);
            Assert.Equal(16, image[3, 0]);
            Assert.Equal(7, image[3, 1]);
            Assert.Equal(10, image[3, 2]);
            Assert.Equal(11, image[3, 3]);
        }

        // 测试非法输入
        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new RotateImage_48().Rotate(null));
            Assert.Throws<ArgumentException>(() => new RotateImage_48().Rotate(new int[0, 0]));
            Assert.Throws<ArgumentException>(() => new RotateImage_48().Rotate(new int[1, 0]));
        }
    }
}
