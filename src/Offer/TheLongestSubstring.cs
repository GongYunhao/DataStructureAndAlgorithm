using System;
using System.Collections.Generic;

namespace Offer
{
    public class TheLongestSubstring
    {
        public static int GetLength(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text), "The input string can't be null");

            Dictionary<char, int> set = new Dictionary<char, int>();
            int left = -1;
            int maxLength = 0;

            for (int right = 0; right <= text.Length - 1; right++)
            {
                if (!set.ContainsKey(text[right]))
                {
                    set.Add(text[right], right);
                }
                else
                {
                    left = set[text[right]] > left ? set[text[right]] : left;
                    set.Remove(text[right]);
                    set.Add(text[right], right);
                }
                maxLength = Math.Max(maxLength, right - left);
            }

            return maxLength;
        }
    }
}
