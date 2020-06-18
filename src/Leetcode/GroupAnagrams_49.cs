using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public class GroupAnagrams_49
    {
        private const int CHAR_RANGE_LENGTH = 26;

        // 占据O(1)的空间复杂度
        int[] array = new int[CHAR_RANGE_LENGTH];
        StringBuilder sb = new StringBuilder();

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                // 提取特征值,作为字典的键
                string feature = ExtractFeature(str);
                // 此处的时间复杂度O(1),空间复杂度O(n)
                if (dictionary.ContainsKey(feature))
                {
                    dictionary[feature].Add(str);
                }
                else
                {
                    dictionary.Add(feature, new List<string> { str });
                }
            }

            return new List<IList<string>>(dictionary.Values);
        }

        // 主体思路没问题,都是从str中提取特征值,这个特征值必须无关顺序,而且能体现各字符的出现次数
        // leetcode上也是这两种思路,字符串内部排序/计数
        // 假设k代表字符串的平均长度
        // 字符串内部排序的时候,可以使用快速排序,平均时间复杂度O(n*klogk)
        // 用数组统计字符串中各字符的出现次数,然后将字符和对应次数拼接起来作为特征值,时间复杂度为O(n*k)
        // 但是考虑到拼接字符串需要操作一个额外的stringbuilder和数组,而字符串排序则会生成一个无法利用的char[]
        // 由于输入参数中,k的数量很小,所以两者的时间复杂度差不多,主要差别还是在常数项上面
        // 需要注意的是,leetcode上代码运行分布也是非常集中,都在350ms-400ms之间,再考虑到它的计时器问题,也许这两种情况都是很好的,实用的
        private string ExtractFeature(string str)
        {
#if false
            // 分配一个char[],空间复杂度O(nk)
            char[] array = str.ToCharArray();
            Array.Sort(array);
            return new string(array);
#else
            foreach (char c in str)
            {
                array[c - 'a']++;
            }

            for (int i = 0; i < CHAR_RANGE_LENGTH; i++)
            {
                if (array[i] > 0)
                {
                    sb.Append(i + 'a').Append(array[i]);
                    array[i] = 0;
                }
            }

            // 分配一个新字符串,包含了字符以及对应的出现次数,长度可大可小,但总共分配的字符串数量有O(n)
            string result = sb.ToString();
            sb.Clear();
            return result;
#endif
        }
    }
}
