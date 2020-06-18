using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class TextJustificationTest
    {
        [Fact]
        public void Test()
        {
            var result = new TextJustification_68().FullJustify(new[]
                {"This", "is", "an", "example", "of", "text", "justification."}, 16);

            Assert.Equal(3, result.Count);
            Assert.Equal("This    is    an", result[0]);
            Assert.Equal("example  of text", result[1]);
            Assert.Equal("justification.  ", result[2]);
        }

        [Fact]
        public void Test1()
        {
            var result = new TextJustification_68().FullJustify(new[]
                {"What","must","be","acknowledgment","shall","be"}, 16);

            Assert.Equal(3, result.Count);
            Assert.Equal("What   must   be", result[0]);
            Assert.Equal("acknowledgment  ", result[1]);
            Assert.Equal("shall be        ", result[2]);
        }

        [Fact]
        public void Test2()
        {
            var result = new TextJustification_68().FullJustify(new[]
            {
                "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain",
                "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"
            }, 20);

            Assert.Equal(6, result.Count);
            Assert.Equal("Science  is  what we", result[0]);
            Assert.Equal("understand      well", result[1]);
            Assert.Equal("enough to explain to", result[2]);
            Assert.Equal("a  computer.  Art is", result[3]);
            Assert.Equal("everything  else  we", result[4]);
            Assert.Equal("do                  ", result[5]);
        }
    }
}
