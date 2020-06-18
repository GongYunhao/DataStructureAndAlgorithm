using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class ThreeSumClosestTest
    {
        [Fact]
        public void Test()
        {
            int result = new ThreeSumClosest_16().ThreeSumClosest(new[] { -1, 2, 1, -4 }, 1);
            Assert.Equal(2, result);
        }
    }
}
