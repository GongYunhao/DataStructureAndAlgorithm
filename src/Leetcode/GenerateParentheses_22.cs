using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public class GenerateParentheses_22
    {
        // 相当于回溯法生成字符串
        public IList<string> GenerateParenthesis(int n)
        {
            if (n <= 0)
                throw new ArgumentException();

            IList<string> result = new List<string>();
            GenerateRecursively(new StringBuilder("("), n, 1, 0, result);
            return result;
        }

        private void GenerateRecursively(StringBuilder sb, int maxCount, int leftCount, int rightCount, IList<string> result)
        {
            // 符合基准条件，说明字符串已经生成结束，可以添加到结果列表中
            if (leftCount == maxCount && rightCount == maxCount)
            {
                result.Add(sb.ToString());
                return;
            }

            // 不符合基准条件，说明还需要继续生成操作；下面有两条路径可供选择，分别是增加左右括号，但是在增加前需要判断能否进入该路径
            if (leftCount < maxCount)
            {
                sb.Append('(');
                GenerateRecursively(sb, maxCount, leftCount + 1, rightCount, result);
                sb.Remove(sb.Length - 1, 1);
            }
            if (rightCount < maxCount && leftCount > rightCount)
            {
                sb.Append(')');
                GenerateRecursively(sb, maxCount, leftCount, rightCount + 1, result);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
