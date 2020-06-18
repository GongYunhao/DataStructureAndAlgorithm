using System;
using System.Collections.Generic;
using System.Text;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class LongestValidParenthesesTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(2, LongestValidParentheses.GetResult(")()("));
            Assert.Equal(2, LongestValidParentheses.GetResult("(()"));
            Assert.Equal(4, LongestValidParentheses.GetResult(")()())"));
            Assert.Equal(6, LongestValidParentheses.GetResult("()(())"));
        }
    }
}
