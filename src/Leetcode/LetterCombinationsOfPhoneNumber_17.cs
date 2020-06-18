using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class LetterCombinationsOfPhoneNumber_17
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null)
                throw new ArgumentNullException();
            if (digits.Length == 0)
                return new List<string>();

            List<string> result = new List<string>();
            LetterCombinationsCore(digits, 0, result, new char[digits.Length]);
            return result;
        }

        private void LetterCombinationsCore(string digits, int offset, List<string> result, char[] charArray)
        {
            if (offset == digits.Length)
            {
                result.Add(new string(charArray));
                return;
            }

            foreach (char newChar in GetLettersByDigit(digits[offset]))
            {
                charArray[offset] = newChar;// 复用charArray，直到offset到达字符串结尾时，将array内容一次性转化成字符串
                LetterCombinationsCore(digits, offset + 1, result, charArray);
            }
        }

        private char[] GetLettersByDigit(char digit)
        {
            return _dictionary[digit - '2'];
        }

        private static readonly char[][] _dictionary =
        {
            new []{'a','b','c'},
            new []{'d','e','f'},
            new []{'g','h','i'},
            new []{'j','k','l'},
            new []{'m','n','o'},
            new []{'p','q','r','s'},
            new []{'t','u','v'},
            new []{'w','x','y','z'},
        };
    }
}
