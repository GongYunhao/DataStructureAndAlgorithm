using System;

namespace Leetcode
{
    public class WildcardMatching_44
    {
        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
                throw new ArgumentNullException();

            int sIndex = 0, pIndex = 0, swIndex = 0, pwIndex = -1;
            while (sIndex < s.Length)
            {
                // 两个字符串匹配，同时推进两个指针
                if (pIndex < p.Length && (p[pIndex] == '?' || s[sIndex] == p[pIndex]))
                {
                    sIndex++;
                    pIndex++;
                }
                // 发现*号，将pattern指针移动到下一个字符，并记录当前指针
                else if (pIndex < p.Length && p[pIndex] == '*')
                {
                    pIndex++;
                    pwIndex = pIndex;
                    swIndex = sIndex;
                }
                // 两个字符串既不匹配，也不等于*号
                else if (pwIndex != -1)
                {
                    pIndex = pwIndex;
                    swIndex++;
                    sIndex = swIndex;
                }
                // 如果从未找到过任何*号，并且当前字符不匹配，也不等于*，说明两个字符串绝无可能匹配，直接返回false
                // 哪怕之前能找到一个*号，都需要接着匹配剩余字符串，直到指针移动到s的末尾
                else
                    return false;
            }

            // 上面循环当s移动到末尾时结束，此时p中可能还有剩余字符串，但是剩下的字符只能是*号
            while (pIndex < p.Length && p[pIndex] == '*')
                pIndex++;

            return pIndex == p.Length;// 当去除了所有*号后，查看p是否也移动到了字符串的末尾
        }
    }
}
