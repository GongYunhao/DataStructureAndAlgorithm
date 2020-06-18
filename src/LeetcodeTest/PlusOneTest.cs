using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class PlusOneTest
    {
        [Fact]
        public void Test()
        {
            var result = new PlusOne_66().PlusOne(new[] { 1, 2, 3 });
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(4, result[2]);
        }
    }
}
