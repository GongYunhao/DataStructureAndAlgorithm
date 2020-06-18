using System;

namespace Leetcode
{
    public class RotateImage_48
    {
        public void Rotate(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "The input image can't be null");

            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            if (rowCount != columnCount || rowCount == 0 || columnCount == 0)
                throw new ArgumentException("The input image is not square", nameof(matrix));

            // 遍历分割区域内的所有元素，将其与其他区域内的对应元素调换位置，遍历结束后，整个图像就被旋转
            // 问题在于如何分割图像，需要考虑两种情况
            // 第一种图像的边长为偶数，只需要将图像四等分即可
            // 第二种图像的边长为奇数，此时如果简单四等分，会遇到区域重叠或者是未覆盖的情况
            // 假如将图像最中心位置的一个像素称为C点，需要着重考虑C点上下左右四条区域，因为普通的区分方式这四个区域会同时属于两个子区块
            // 可以考虑每个子区块只拥有一个区域（类似嘉禾电影logo），这样四个区域大小形状都相等了，中心C点没有覆盖到，但是考虑到我们需要旋转图像，所以中心点是不会变动的
            for (int i = 0; i < rowCount / 2; i++)
            {
                for (int j = 0; j <= (columnCount - 1) / 2; j++)
                {
                    SwapQuadrant(matrix, rowCount - 1, columnCount - 1, i, j);
                }
            }
        }

        private void SwapQuadrant(int[,] image, int maxRowIndex, int maxColumnIndex, int a, int b)
        {
            int tmp = image[a, b];
            image[a, b] = image[maxRowIndex - b, a];
            image[maxRowIndex - b, a] = image[maxRowIndex - a, maxColumnIndex - b];
            image[maxRowIndex - a, maxColumnIndex - b] = image[b, maxColumnIndex - a];
            image[b, maxColumnIndex - a] = tmp;
        }
    }
}
