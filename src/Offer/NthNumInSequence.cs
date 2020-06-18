namespace Offer
{
    public class NthNumInSequence
    {
        public static int GetResult(int index)
        {
            // 0需要单独考虑,因为while循环中currentLevel需要*10,只能从1开始
            if (index == 0)
                return 0;

            // 本题的基本思想是将数字分段,1-9一段,10-99一段,100-999一段....依此类推
            // 当输入一个index时,首先要确定这个序号将落在哪一个数字段内,就是这一段while代码所做的工作
            int startIndexInSequence = 1;// 当前数字段的起始序号
            int currentLevel = 1;// 在当前数字段上,起始序号所在的"完整的数字"
            int numberCount = 1;// 当前数字段上,对应的数字位数
            // 以上三个变量表达的意思是当前数字段的起始数字是1,在字符串中的序号是1(从0开始计数),并且每个完整数字包含1个数字符号

            // 检测index最终将落在哪一个数字段内,并将上面三个变量设定为对应数字段的值
            while (index > startIndexInSequence + (numberCount) * 9 * currentLevel - 1)
            {
                startIndexInSequence += (numberCount) * 9 * currentLevel;
                numberCount++;
                currentLevel *= 10;
            }

            // 计算index所在数字与数字段起始数字的差值
            int count = (index - startIndexInSequence) / (numberCount);
            // 计算index指向的数字字符,在所属的数字中的位置
            // 注意这里的位置,以一个五位数为例,余数总共有五种可能0,1,2,3,4,分别对应数字中的不同位数
            int remain = (index - startIndexInSequence) % (numberCount);

            int currentNum = currentLevel + count;// 计算当前指向的数字
            for (int i = numberCount - 1; i > remain; i--)
            {
                // 将数字末尾去除对应的位数,结束循环时,最后一位即为index对应的数字
                currentNum /= 10;
            }
            return currentNum % 10;// 取最后一位数字作为结果
        }
    }
}
