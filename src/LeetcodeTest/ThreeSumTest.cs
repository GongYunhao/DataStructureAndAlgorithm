using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class ThreeSumTest
    {
        [Fact]
        public void Test()
        {
            var result = new ThreeSum_15().ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
            Assert.Equal(2, result.Count);
            Assert.True(result[0].ContainsSameElement(new[] { -1, -1, 2 }));
            Assert.True(result[1].ContainsSameElement(new[] { -1, 0, 1 }));
        }
    }
}
