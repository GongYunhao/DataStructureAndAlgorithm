using System;

namespace Offer
{
    public class InversePairsCount
    {
        public static int GetCount(int[] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (data.Length <= 1)
                return 0;

            int[] copy = new int[data.Length];
            Array.Copy(data, copy, data.Length);

            return GetCountRecursively(data, copy, 0, data.Length - 1);
        }

        // 总体上是和归并排序差不多的,区别在于需要统计逆序对的数量
        // 逆序对统计需要考虑三种情况: 1.存在于左半侧中的逆序对 2.右半侧逆序对 3.跨越两侧的逆序对
        // 其中1和2情况可以通过递归方式解决,问题在于第三种 可以从归并排序的特性入手
        // 归并排序的左右两侧都是分别排序的,这样一来就不需要考虑两侧内部的逆序对了,只需要考虑跨越两侧的情况
        // 逆序对究其根源,在于违反了从小到大的排序造成的
        // 我们可以从两侧的最大值着手去看 如果左侧的最大值大于右侧的最大值,那么就存在逆序对,相反的情况则不算逆序对
        // 又考虑到右侧包含多个元素,这些都可以和左侧的最大值组成逆序对,所以总的数量等于右侧元素的总数量
        // 然后将左侧的最大值剔除出考虑范围,对下一个左侧最大值进行同样的计算
        // 最后得到的结果就是本轮中,跨越两侧的逆序对数量,再加上两侧内部逆序对数量,就是本区域中逆序对的数量
        // 函数返回这个值,作为上一轮递归的中间结果
        // 当递归完成的时候,就是整个数组的逆序对数量,而且数组已经经过排序
        private static int GetCountRecursively(int[] data, int[] copy, int left, int right)
        {
            if (left == right)
                return 0;// 基准情况,当目标区域内只有一个元素的时候,逆序对数量为0

            // 分别计算左右两侧逆序对数量,并将data分别排序(注意这里data和copy参数是反过来的)
            int middle = (left + right) / 2;
            int leftInnerCount = GetCountRecursively(copy, data, left, middle);
            int rightInnerCount = GetCountRecursively(copy, data, middle + 1, right);

            int crossCount = 0;// 定义跨越两侧逆序对的数量

            int leftIndex = middle;
            int rightIndex = right;
            int currentIndexForCopy = right;

            while (leftIndex >= left && rightIndex >= middle + 1)
            {
                if (data[leftIndex] > data[rightIndex])
                {
                    copy[currentIndexForCopy] = data[leftIndex];
                    crossCount += rightIndex - middle;// 每次判断添加的逆序对数量和右侧总元素数量有关
                    leftIndex--;
                }
                else
                {
                    copy[currentIndexForCopy] = data[rightIndex];
                    rightIndex--;
                }

                currentIndexForCopy--;
            }

            // 当左侧或者右侧元素判断结束以后,将剩余的元素复制到copy数组中
            for (; leftIndex >= left; leftIndex--)
            {
                copy[currentIndexForCopy] = data[leftIndex];
                currentIndexForCopy--;
            }
            for (; rightIndex >= middle + 1; rightIndex--)
            {
                copy[currentIndexForCopy] = data[rightIndex];
                currentIndexForCopy--;
            }

            // Array.Copy(copy,data,data.Length);
            // 如果上面递归函数处,两个变量没有对调,那么这里需要这一行代码,将copy复制到data中,这样函数返回以后,上一层循环才能正确读到数据
            // 但是这里采用了对调的变量,也就是说经过排序后的数据,是写入到了copy数组中,那么对于上一轮循环来说,是写到了data数组中
            // 上一轮循环从data中读取数据,再写到copy中去
            // 也就是两个数组轮换发挥读写功能

            return leftInnerCount + rightInnerCount + crossCount;
        }
    }
}
