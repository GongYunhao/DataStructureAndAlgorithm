namespace Leetcode
{
    public class PalindromeNumber_9
    {
        public bool IsPalindrome(int x)
        {
            // Special cases:
            // As discussed above, when x < 0, x is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome,
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            // 一开始也是想要这种方案的，但是“10”这个结果不对
            // 修改以后ok，不同点在于首先修改revertedNumber，同时将x除以10，直到x小于等于翻转的数字
            // 此时如果两者相等，属于恰好平分数字的情况；若翻转的数字较大，属于两者共用一个中心数字的情况
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // When the length is an odd number, we can get rid of the middle digit by revertedNumber/10
            // For example when the input is 12321, at the end of the while loop we get x = 12, revertedNumber = 123,
            // since the middle digit doesn't matter in palidrome(it will always equal to itself), we can simply get rid of it.
            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
