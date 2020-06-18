using System.Linq;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class CombinationSumsTest
    {
        [Fact]
        public void Test()
        {
            var result = new CombinationSums_39().CombinationSum(new[] { 2, 3, 6, 7 }, 7);
            Assert.Equal(2, result.Count);

            Assert.Single(result, o => o.Count == 1 && o[0] == 7);
            Assert.Single(result, o => o.Count == 3 && o.Count(a => a == 2) == 2 && o.Count(a => a == 3) == 1);
        }
    }
}
