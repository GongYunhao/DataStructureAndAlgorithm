using System;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class ImplementstrStrTest
    {
        [Fact]
        public void NormalTest()
        {
            Assert.Equal(2, new ImplementstrStr_28().StrStr("hello", "ll"));
            Assert.Equal(0, new ImplementstrStr_28().StrStr("hello", "hello"));
            Assert.Equal(4, new ImplementstrStr_28().StrStr("hello", "o"));

            Assert.Equal(16, new ImplementstrStr_28().StrStr("aaaaaaaaaaaaaaaaaaaaaaab", "aaaaaaab"));
        }

        [Fact]
        public void NotFound()
        {
            Assert.Equal(-1, new ImplementstrStr_28().StrStr("hello", "b"));
            Assert.Equal(-1, new ImplementstrStr_28().StrStr("hello", "helloworld"));
            Assert.Equal(-1, new ImplementstrStr_28().StrStr("hello", "elo"));
        }

        [Fact]
        public void SpecialInput()
        {
            Assert.Equal(0, new ImplementstrStr_28().StrStr("hello", ""));
            Assert.Equal(0, new ImplementstrStr_28().StrStr("", ""));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => new ImplementstrStr_28().StrStr(null, "369"));
            Assert.Throws<ArgumentNullException>(() => new ImplementstrStr_28().StrStr(null, ""));
            Assert.Throws<ArgumentNullException>(() => new ImplementstrStr_28().StrStr(null, null));

            Assert.Throws<ArgumentNullException>(() => new ImplementstrStr_28().StrStr("225874", null));
            Assert.Throws<ArgumentNullException>(() => new ImplementstrStr_28().StrStr("", null));
        }
    }
}
