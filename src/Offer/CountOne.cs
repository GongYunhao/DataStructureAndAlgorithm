using System;

namespace Offer
{
    public class CountOne
    {
        public static int CountOneResult(int max)
        {
            return CountOneRecursively(max);
        }

        private static int CountOneRecursively(int max)
        {
            if (max == 0)
                return 0;

            // exponent变量代表当前数字最高位对应的十进制乘方数,比如12345的最高位是10000,则对应的exponent为4
            // 每次递归需要单独计算这个数组,因为递归时候需要取余数,当余数最高位为0时,这个0将被抛弃,如果机械地去将exponent减去1,则两个变量将不匹配
            // 比如101%100余1,而指数如果减去1,将对应到十位数,而不是个位数
            int exponent = 0;

            int tmp = max;
            while (tmp >= 10)
            {
                exponent++;
                tmp = tmp / 10;
            }

            int count = 0;// 记录当前循环下数字"1"的个数
            // 记录下当前指数情况下,需要集中关注的位数,若需要关注万位数,则指数应当为4,currentLevel变量为10000
            int currentLevel = Convert.ToInt32(Math.Pow(10, exponent));

            // 计算最高位上数字1出现的次数
            if (max / currentLevel == 1)
                // 比如说在1000-1130区间上,千位数上'1'一共出现过131次
                count += max - max / currentLevel * currentLevel + 1;
            else
                // 在1000-2000区间上,千位数共出现过1000个'1'
                count += currentLevel;

            // 此处是最难想通的
            // 以1130为例
            // 将其分成两个区间,0-130和131-1130,我们集中关注后一个区间
            // 131-1130,其中千位数上'1'一共出现过131次(因为小于1000的值它们的千位数都是0)
            // 然后关注后三位:
            // 由于要计算'1'的个数,我们可以让三位中的任一位固定为1,其他两位从0-9排列组合,所以在131-1130之间,后三位上'1'一共出现过3*10^2=300次
            // 需要考虑到区间跨度可能为1000的倍数,2000或3000都有可能,这里我们只需要考虑1000的情况即可
            // 所以在131-1130区间内,'1'共出现了131+300=431次
            // 接下来用递归方式考虑0-130区间内的次数,累加即可得到最终结果
            // 尤其要注意基准情况,max==0,由于我们这样一次减少一位数,倒数第二轮必定是1-9或者10的n次方如10,100等,都可以按照套路来计算
            // 那么对于0,就要写入基准情况,这样在计算最终落入倒数第二轮之后,下一轮递归(取余数)就会落入基准情况,计算就可以一层层向上结束
            count += max / currentLevel * exponent * Convert.ToInt32(Math.Pow(10, exponent - 1));
            count += CountOneRecursively(max % currentLevel);
            return count;
        }
    }
}
