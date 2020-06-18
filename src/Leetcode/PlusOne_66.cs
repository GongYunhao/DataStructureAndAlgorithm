using System;

namespace Leetcode
{
    public class PlusOne_66
    {
        public int[] PlusOne(int[] digits)
        {
            if (digits == null || digits.Length == 0)
                return digits;

            int[] result = digits;

            int currentIndex = digits.Length - 1;

            result[currentIndex]++;

            
            int carry = 0;
            while (currentIndex >= 0)
            {
                int sum = result[currentIndex] + carry;
                carry = sum / 10;
                result[currentIndex] = sum % 10;

                currentIndex--;
            }

            if (carry > 0)
            {
                result = new int[digits.Length + 1];
                Array.Copy(digits, 0, result, 1, digits.Length);
                result[0] = carry;
            }

            return result;
        }
    }
}
