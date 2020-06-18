using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class DivideTwoIntegersTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(3, new DivideTwoIntegers_29().Divide(10, 3));
            Assert.Equal(-2, new DivideTwoIntegers_29().Divide(7, -3));
        }

        [Fact]
        public void SpecialTest()
        {
            Assert.Equal(0, new DivideTwoIntegers_29().Divide(0, 3));
            Assert.Equal(0, new DivideTwoIntegers_29().Divide(0, -3));

            Assert.Equal(int.MaxValue, new DivideTwoIntegers_29().Divide(int.MaxValue, 1));
            Assert.Equal(-int.MaxValue, new DivideTwoIntegers_29().Divide(int.MaxValue, -1));

            Assert.Equal(int.MinValue, new DivideTwoIntegers_29().Divide(int.MinValue, 1));
            Assert.Equal(int.MaxValue, new DivideTwoIntegers_29().Divide(int.MinValue, -1));
        }

        [Fact]
        public void BugFoundInLeetcode()
        {
            Assert.Equal(-1073741824, new DivideTwoIntegers_29().Divide(int.MinValue, 2));
        }
    }
}
