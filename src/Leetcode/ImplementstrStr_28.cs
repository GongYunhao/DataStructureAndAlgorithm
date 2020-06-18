using System;

namespace Leetcode
{
    public class ImplementstrStr_28
    {
        private const int NotFound = -1;
        private const int DefaultResult = 0;

        public int StrStr(string haystack, string needle)
        {
            if (haystack == null || needle == null)
                throw new ArgumentNullException();

            if (needle == string.Empty)
                return DefaultResult;

            if (haystack.Length < needle.Length)
                return NotFound;

            int leftIndex = 0, rightIndex = needle.Length - 1;

            while (rightIndex <= haystack.Length - 1)
            {
                if (haystack[leftIndex] == needle[0]
                    && haystack[rightIndex] == needle[needle.Length - 1]
                    && IsMatch(haystack, needle, leftIndex, rightIndex))
                    return leftIndex;

                leftIndex++;
                rightIndex++;
            }

            return NotFound;
        }

        private bool IsMatch(string haystack, string needle, int leftIndex, int rightIndex)
        {
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                if (haystack[i] != needle[i - leftIndex])
                    return false;
            }

            return true;
        }
    }
}
