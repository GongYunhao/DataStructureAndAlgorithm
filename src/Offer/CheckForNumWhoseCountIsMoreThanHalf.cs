#define SWITCH
using System;

namespace Offer
{
    public class CheckForNumWhoseCountIsMoreThanHalf
    {
        public static int GetResult(int[] array)
        {

            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length == 0)
                throw new ArgumentException(nameof(array));
#if SWITCH
            // 相比之下,这种方法就好的多了,也稳定得多
            // 从第一个数开始,遍历所有元素,维护两个变量记录原数字和数字出现的次数,当新数字与原数字相等时,给次数加上1,否则减去1;如果次数为0,则将当前数字作为原数字,并且次数修改为1
            // 一轮遍历结束,如果存在一个数字,其出现次数占到一半以上,那么它必定会保留在结果中,因为其他所有数字频率之和就比不上这个数字
            // 当然,如果这个数字不存在,函数也是会给出一个数字,所以最后检验一下该数字是否确实超过一半即可,遍历两遍即可求出结果
            int result = 0;
            int count = 0;

            foreach (var item in array)
            {
                if (item == result)
                    count++;
                else
                    count--;

                if (count <= 0)
                {
                    result = item;
                    count = 1;
                }
            }

            if (CheckMoreThanHalf(array, result))
                return result;
#else
            // 若对数组进行排序,则数量最多,且超过一半的数字,一定会处在数组的中间位置
            // 所以可以仿照快速排序的方法,将数组划分为两部分,前半部分小于等于选定元,后半部分大于选定元,用这种方式去逼近中间点
            // 而中间点以外的数组是否排序,就不是关注点了(所以相比快速排序可以节省不少时间)
            // 但是书上写的O(n)时间复杂度,个人是存有疑问的,对于partition,o(n)的复杂度没有问题,而且每一次计算其n的规模都在减小,但是总的计算次数存疑,理想状况下是log n,还得是全部集中在左侧或者右侧的情况,很吃数据;而且根据题目所给的条件,有大量数据相同,这对于快速排序简直是灾难,可以直接将整体时间复杂度推到n^2,和插入排序一样(每次划分都只能减少一个元素,共需要划分O(n)次)
            // 还需要注意的是,该函数会修改原始数据,要多和面试官沟通看是否允许修改
            int left = 0;
            int right = array.Length - 1;
            int result = -1;
            while (result != array.Length / 2)
            {
                result = Partition(array, left, right);
                if (result > array.Length / 2)
                {
                    right = result - 1;
                }
                else
                {
                    left = result + 1;
                }
            }

            if (CheckMoreThanHalf(array, array[result]))
            {
                return array[result];
            }
#endif
            throw new ArgumentException(nameof(array));
        }

        // 从数组的指定区域内选取一个元素,然后将数组中的元素重新排序,形成两个区域,前一区域小于该元素,后一区域大于该元素,最后返回分界点的序号
        private static int Partition(int[] array, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
                return startIndex;

            int partition = array[endIndex];
            int left = startIndex;
            int right = endIndex - 1;

            while (left <= right)
            {
                if (array[left] <= partition)
                {
                    left++;
                }
                else
                {
                    Swap(ref array[left], ref array[right]);
                    right--;
                }
            }

            Swap(ref array[left], ref array[endIndex]);
            return left;
        }

        private static void Swap(ref int i, ref int j)
        {
            int tmp = i;
            i = j;
            j = tmp;
        }

        private static bool CheckMoreThanHalf(int[] array, int result)
        {
            int times = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == result)
                    times++;
            }

            return times << 1 > array.Length;
        }
    }
}
