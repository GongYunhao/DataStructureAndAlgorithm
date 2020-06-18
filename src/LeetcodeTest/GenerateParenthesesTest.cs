using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class GenerateParenthesesTest
    {
        [Fact]
        public void NormalTest()
        {
            var result = new GenerateParentheses_22().GenerateParenthesis(3);
            Assert.Equal(5, result.Count);
        }
    }
}
