using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class UniquePathsTest
    {
        [Fact]
        public void test()
        {
            //Assert.Equal(3, new UniquePaths_62().UniquePaths(3, 2));
            Assert.Equal(28, new UniquePaths_62().UniquePaths(3, 7));
        }
    }
}
