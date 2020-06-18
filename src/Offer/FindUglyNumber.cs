using System;

namespace Offer
{
    public class FindUglyNumber
    {
        // 最开始的想法是用类似回溯法的方法生成要求数量的丑数,剔除掉重复值后根据序号取值
        // 这样应该也是可以的,但是时间效率较低,而且临时变量会占据很多的内存空间
        // 接下来的方法是书上写的
        // 针对每个已经生成的丑数,将它们分别乘以2,3,5 会得到一系列值,挑选其中大于当前丑数序列最大值,且最小的一个数,添加到序列中,这样最终生成的丑数序列就是排好顺序的
        // 进一步优化,我们可以看出来,每次将序列元素进行乘操作时,最终会有很多多余的元素参与排序
        // 由于我们只需要刚好大于丑数序列最大值的一个值,那我们可以从*2,*3,*5的序列中分别取出刚好大于丑数的那个值进行比对
        // 比对完成后,将这个最小值放入丑数序列
        // 其实还有优化空间:如果我们将恰好大于当前丑数最大值的那个序号记录下来,就不需要每次去计算所有的值,只需要计算序号所指向的元素*2,*3,*5后值的大小即可
        public static int GetByIndex(int index)
        {
            int[] tmpResults = new int[index];
            tmpResults[0] = 1;// 第一个丑数为1,是丑数序列的起始位置和条件

            int t2Index = 0, t3Index = 0, t5Index = 0;// *2,*3,*5序列的起始位置都设置为0

            // 重复计算过程,直到数组填满
            int currentIndex = 0;
            while (currentIndex < index - 1)
            {
                currentIndex++;// 先移动指针再计算,这样可以使计算次数=移动数目,而且每次计算的都是"本元素"
                               // 当指针指向最后一个元素,完成计算后就结束了,不需要绕圈子去设定"下一个元素的指针"

                int currentUglyNum = Min(tmpResults[t2Index] * 2, tmpResults[t3Index] * 3, tmpResults[t5Index] * 5);
                tmpResults[currentIndex] = currentUglyNum;// 分别取*2,*3,*5序列中,大于当前丑数且最小的那一个作为丑数序列的新元素

                // 新丑数已经添加,几个指针都要移动到新的临界点,这样下一个循环就可以通过一次乘法获取新的候选丑数
                // 之所以用<=符号,是因为在下一轮循环中需要候选丑数大于当前丑数,所以当两者相等时,指针要再移动一格
                while (tmpResults[t2Index] * 2 <= currentUglyNum)
                    t2Index++;
                while (tmpResults[t3Index] * 3 <= currentUglyNum)
                    t3Index++;
                while (tmpResults[t5Index] * 5 <= currentUglyNum)
                    t5Index++;
            }

            return tmpResults[index - 1];// 计算全部完成,从给定序号对应的位置上取得元素
        }

        private static int Min(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
    }
}
