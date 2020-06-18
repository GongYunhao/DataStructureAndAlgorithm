using System.Collections.Generic;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class InsertIntervalTest
    {
        [Fact]
        public void test()
        {
            List<Interval>  list = new List<Interval>{new Interval(1,3),new Interval(6,9)};
            var result = new InsertInterval_57().Insert(list, new Interval(2, 5));

            Assert.Equal(2,result.Count);
        }
    }
}
