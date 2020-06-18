using System;

namespace Leetcode
{
    public class LongestCommonPrefix_14
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null)
                throw new ArgumentNullException();
            if (strs.Length == 0)
                return string.Empty;
            if (strs.Length == 1)
                return strs[0];

            int minLength = int.MaxValue;
            foreach (string s in strs)
            {
                minLength = s.Length < minLength ? s.Length : minLength;
            }

            if (minLength == 0)
                return string.Empty;

            int lastPrefixIndex = -1;
            while (lastPrefixIndex < minLength - 1 && SameCharAtIndex(strs, lastPrefixIndex + 1))
            {
                lastPrefixIndex++;
            }

            if (lastPrefixIndex == -1)
                return string.Empty;
            else
                return strs[0].Substring(0, lastPrefixIndex + 1);
        }

        private bool SameCharAtIndex(string[] strs, int index)
        {
            foreach (string s in strs)
            {
                if (s[index] != strs[0][index])
                    return false;
            }
            return true;
        }
    }
}
