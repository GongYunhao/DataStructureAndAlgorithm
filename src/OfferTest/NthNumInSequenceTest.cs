using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class NthNumInSequenceTest
    {
        private static string _text = null;

        static NthNumInSequenceTest()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= 100000; i++)
                sb.Append(i.ToString());
            _text = sb.ToString();
        }

        [Fact]
        public void Test()
        {
            for (int i = 0; i <= 11111; i++)
                Assert.Equal(_text[i] - '0', NthNumInSequence.GetResult(i));
        }
    }
}
