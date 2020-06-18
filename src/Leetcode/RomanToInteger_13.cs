using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class RomanToInteger_13
    {
        public int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int result = 0;
            for (int i = 0; i <= s.Length - 2; i++)
            {
                int preInt = GetIntFromRomanChar(s[i]);
                int postInt = GetIntFromRomanChar(s[i + 1]);

                if (preInt < postInt)
                    result -= preInt;
                else
                    result += preInt;
            }
            result += GetIntFromRomanChar(s[s.Length - 1]);
            return result;
        }

        private int GetIntFromRomanChar(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
