using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class CuttingRod
    {
        public static int GetMaxResultUsingDP(int length)
        {
            if (length < 2)
                return 0;
            if (length == 2)
                return 1;
            if (length == 3)
                return 2;

            int[] tmpResult = new int[length + 1];
            // 题目中要求乘数,所有长度的绳子,不做切割也可以参与计算
            // 所以给各种长度的绳子一个默认值(等于绳子自身长度)
            // 待到遍历完所有情况(包括未分割,已分割)以后,再确定绳子所能提供的最大乘积
            tmpResult[0] = 1;
            for (int i = 1; i <= length; i++)
                tmpResult[i] = i;
            // 原代码中,以长度4为分界,低于这个长度直接赋值,是因为小于4的绳子,无论如何分割,都比不上不分割所能提供的乘数值;
            // 而长度等于4,则分割与否结果是一致的;
            // 长度大于4,分割后的最大乘积总能大于原始长度

            for (int i = 0; i <= length; i++)
            {
                int max = 0;
                for (int j = 0; j <= i / 2; j++)
                {
                    max = Math.Max(max, tmpResult[j] * tmpResult[i - j]);
                }

                tmpResult[i] = max;
            }

            return tmpResult[length];
        }
    }
}
