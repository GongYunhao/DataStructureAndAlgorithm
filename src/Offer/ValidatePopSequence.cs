using System;
using System.Collections.Generic;

namespace Offer
{
    public class ValidatePopSequence
    {
        public static bool IsSequence(int[] inArray, int[] outArray)
        {
            if (inArray == null || outArray == null)
                throw new ArgumentNullException("The given array can't be null");
            if (inArray.Length != outArray.Length)
                return false;

            Stack<int> stack = new Stack<int>();
            int outIndex = 0;
            for (int i = 0; i <= inArray.Length - 1; i++)
            {
                stack.Push(inArray[i]);

                while (stack.Count != 0 && stack.Peek() == outArray[outIndex])
                {
                    stack.Pop();
                    outIndex++;
                }
            }

            return stack.Count == 0 && outIndex == outArray.Length;
        }
    }
}
