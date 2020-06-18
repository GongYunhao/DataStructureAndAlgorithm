using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class JumpGameIITest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(2, new JumpGameII_45().Jump(new[] { 2, 3, 1, 1, 4 }));
        }

        [Fact]
        public void BugFoundInLeetcode()
        {
            Assert.Equal(2, new JumpGameII_45().Jump(new[] { 9, 7, 9, 4, 8, 1, 6, 1, 5, 6, 2, 1, 7, 9, 0 }));
        }

        [Fact]
        public void Bug2FoundInLeetcode()
        {
            Assert.Equal(1, new JumpGameII_45().Jump(new[] { 2, 3, 1 }));
        }

        [Fact]
        public void Bug3FoundInLeetcode()
        {
            Assert.Equal(0, new JumpGameII_45().Jump(new[] { 0 }));
        }
    }
}
