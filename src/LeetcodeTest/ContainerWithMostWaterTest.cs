using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class ContainerWithMostWaterTest
    {
        [Fact]
        public void test()
        {
            Assert.Equal(49,new ContainerWithMostWater_12().MaxArea(new []{ 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }
    }
}
