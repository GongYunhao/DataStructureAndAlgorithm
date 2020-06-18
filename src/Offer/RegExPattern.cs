using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Offer
{
    public class RegExPattern
    {
        public static bool IsMatch(string source, string pattern)
        {
            if (source == null || pattern == null)
                throw new ArgumentNullException("The input source string can't be null");

            return MatchCore(source, pattern);
        }

        private static bool MatchCore(string source, string pattern)
        {
            // 如果正则表达式为空,则输入字符串必须也为空才能匹配
            if (string.IsNullOrEmpty(pattern))
                return string.IsNullOrEmpty(source);

            // 比对第一个字符是否匹配
            bool firstMatch = !string.IsNullOrEmpty(source) && (source[0] == pattern[0] || pattern[0] == '.');

            // 如果正则表达式长度大于等于2,且第二个字符是*号,需要考虑两种可能:
            // (1)正则表达式最初的两个字符匹配不到,这是正常情况,因为*号可以表示0个字符
            // (2)正则表达式最初的两个字符可以匹配输入字符串的第一个字符,需要考虑后续能否匹配
            // 如果正则表达式长度小于2,或者大于2但是第二个字符不是*号,此时也只要匹配第一个字符即可,后续匹配交给递归处理
            if (pattern.Length >= 2 && pattern[1] == '*')
            {
                // 此行代码需要考虑表达式的先后逻辑关系,以此来避免运行某些明显会发生错误的代码
                // 如source = string.Empty时,source.Substring(1)会报错,但是和firstMatch做与运算后,这一表达式被短路,不需要计算即可返回结果
                return MatchCore(source, pattern.Substring(2)) ||
                       (firstMatch && MatchCore(source.Substring(1), pattern));
            }
            else
            {
                return firstMatch && MatchCore(source.Substring(1), pattern.Substring(1));
            }
        }
    }
}
