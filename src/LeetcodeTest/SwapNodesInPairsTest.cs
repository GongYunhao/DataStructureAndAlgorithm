using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class SwapNodesInPairsTest
    {
        [Fact]
        public void NormalTest()
        {
            var list = new MyLinkedListNode(1)
            {
                Next = new MyLinkedListNode(2)
                {
                    Next = new MyLinkedListNode(3)
                    {
                        Next = new MyLinkedListNode(4)
                    }
                }
            };

            var result = new SwapNodesInPairs_24().SwapPairs(list);
            Assert.Equal(2, result.Value);
            Assert.Equal(1, result.Next.Value);
            Assert.Equal(4, result.Next.Next.Value);
            Assert.Equal(3, result.Next.Next.Next.Value);
            Assert.Null(result.Next.Next.Next.Next);
        }
    }
}
