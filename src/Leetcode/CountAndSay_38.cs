using System;
using System.Text;

namespace Leetcode
{
    public class CountAndSay_38
    {
        // 这道题在网站上的描述非常模糊，这里重新描述一下
        // 如果一个字符串是“1”，那么我们可以这么描述它“一个1”，也就是“11”
        // 而对于“11”，我们可以说“两个1”，也就是“21”
        // 那么像这样把前一个字符串的数字描述形式，作为下一个字符串的原始数据，而我们需要输出这个原始数据的数字描述，是一个循环的过程
        public string CountAndSay(int n)
        {
            if (n < 1 || n > 30)
                throw new ArgumentException("The input number should be not less than 1 and not bigger than 30", nameof(n));

            string result = "1";
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < n; i++)// 手动设定第一个字符串“1”，所以只有从2开始才需要进入循环
            {
                int startIndex = 0;
                for (int charIndex = 0; charIndex <= result.Length; charIndex++)
                {
                    // 当charIndex到达文字末尾的时候，说明startIndex开始直到末尾都是相同的字符
                    if (charIndex == result.Length)
                    {
                        sb.Append(charIndex - startIndex).Append(result[startIndex]);
                        break;
                    }

                    // 在循环过程中发现字符不同，表明遇到了分界点，需要添加字符数量和字符本身，并将startIndex修改到最新值
                    if (result[startIndex] != result[charIndex])
                    {
                        sb.Append(charIndex - startIndex).Append(result[startIndex]);
                        startIndex = charIndex;
                    }
                }

                // 循环结束，将字符串保存下来
                result = sb.ToString();
                sb.Clear();
            }

            return result;
        }
    }
}
