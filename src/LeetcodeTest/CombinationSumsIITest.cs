using System.Linq;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class CombinationSumsIITest
    {
        [Fact]
        public void Test()
        {
            var result = new CombinationSumsII_40().CombinationSum2(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            Assert.Equal(4, result.Count);

            Assert.Single(result, o => o.Count == 2 && o.Count(a => a == 1) == 1 && o.Count(a => a == 7) == 1);
            Assert.Single(result, o => o.Count == 3 && o.Count(a => a == 1) == 1 && o.Count(a => a == 2) == 1 && o.Count(a => a == 5) == 1);
            Assert.Single(result, o => o.Count == 2 && o.Count(a => a == 2) == 1 && o.Count(a => a == 6) == 1);
            Assert.Single(result, o => o.Count == 3 && o.Count(a => a == 1) == 2 && o.Count(a => a == 6) == 1);
        }

        [Fact]
        public void Test1()
        {
            var result = new CombinationSumsII_40().CombinationSum2(new[] { 1, 7, 1 }, 8);
            Assert.Equal(1, result.Count);

            Assert.Single(result, o => o.Count == 2 && o.Count(a => a == 1) == 1 && o.Count(a => a == 7) == 1);
        }

        [Fact]
        public void Test2()
        {
            var result = new CombinationSumsII_40().CombinationSum2(new[] { 1, 7, 1 }, 9);
            Assert.Equal(1, result.Count);

            Assert.Single(result, o => o.Count == 3 && o.Count(a => a == 1) == 2 && o.Count(a => a == 7) == 1);
        }

        [Fact]
        public void BugFoundInLeetcode()
        {
            var result = new CombinationSumsII_40().CombinationSum2(new[] { 1, 1 }, 2);
            Assert.Equal(1, result.Count);
            Assert.Single(result, o => o.Count == 2 && o.Count(a => a == 1) == 2);
        }

        [Fact]
        public void Bug2FoundInLeetcode()
        {
            var result = new CombinationSumsII_40().CombinationSum2(new[] { 2, 5, 2, 1, 2 }, 5);
            Assert.Equal(2, result.Count);
        }
    }
}
