using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class ValidParenthesesTest
    {
        [Fact]
        public void Test()
        {
            Assert.True(new ValidParentheses_20().IsValid(""));

            Assert.True(new ValidParentheses_20().IsValid("()"));
            Assert.True(new ValidParentheses_20().IsValid("({{[]}})"));
            Assert.True(new ValidParentheses_20().IsValid("()[]"));

            Assert.False(new ValidParentheses_20().IsValid("("));
            Assert.False(new ValidParentheses_20().IsValid("()())"));
            Assert.False(new ValidParentheses_20().IsValid("()())("));

            Assert.False(new ValidParentheses_20().IsValid("()())6("));
        }
    }
}
