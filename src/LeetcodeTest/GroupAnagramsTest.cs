using System.Collections.Generic;
using System.Linq;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class GroupAnagramsTest
    {
        [Fact]
        public void Test()
        {
            GroupAnagrams_49 g = new GroupAnagrams_49();
            IList<IList<string>> lists = g.GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            Assert.Equal(3, lists.Count);

            IList<string> list1 = lists.Single(o => o.Count == 3);
            Assert.Contains("eat", list1);
            Assert.Contains("ate", list1);
            Assert.Contains("tea", list1);

            IList<string> list2 = lists.Single(o => o.Count == 2);
            Assert.Contains("nat", list2);
            Assert.Contains("tan", list2);

            IList<string> list3 = lists.Single(o => o.Count == 1);
            Assert.Contains("bat", list3);
        }
    }
}
