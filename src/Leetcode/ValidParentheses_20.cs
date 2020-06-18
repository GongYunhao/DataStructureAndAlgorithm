using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class ValidParentheses_20
    {
        public bool IsValid(string s)
        {
            if (s == null)
                throw new ArgumentNullException();
            if (s.Length == 0)
                return true;

            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (stack.Count != 0 &&
                         (c == ')' && stack.Peek() == '(' ||
                          c == ']' && stack.Peek() == '[' ||
                          c == '}' && stack.Peek() == '{'))
                {
                    stack.Pop();
                }
                else
                    return false;
            }

            return stack.Count == 0;
        }
    }
}
