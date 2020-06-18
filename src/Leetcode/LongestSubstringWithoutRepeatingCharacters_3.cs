using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class LongestSubstringWithoutRepeatingCharacters_3
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null)
                throw new ArgumentNullException();
            if (s.Length <= 1)
                return s.Length;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            int maxLength = 0;
            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    // 当表中已存在字符时，需要判断这个字符的位置是否处在有效范围内
                    // 因为当发现重复字符时，起始位置将移动到上一个同样字符的后方，使得起始位置到当前位置范围内没有重复字符
                    // 这样的副作用就是会跳过很多的中间字符，他们仍保留在hash表中，但是如果再次遇到，不应该在考虑范围内

                    // 如果字符位置处在有效范围内，就将有效范围的起始位置移动到该字符的后面
                    if (dic[s[i]] >= startIndex)
                    {
                        startIndex = dic[s[i]] + 1;
                    }

                    dic.Remove(s[i]);// 删除重复的字符
                }

                // 重新添加“字符-当前位置”键值对，并更新最大长度
                dic.Add(s[i], i);
                maxLength = Math.Max(maxLength, i - startIndex + 1);
            }

            return maxLength;
        }
    }
}
