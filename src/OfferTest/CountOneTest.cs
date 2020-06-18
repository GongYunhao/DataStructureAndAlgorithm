using Offer;
using Xunit;

namespace OfferTest
{
    public class CountOneTest
    {
        private static int GetResultByBruteForce(int num)
        {
            int number = 0;

            for (int i = 0; i <= num; i++)
            {
                number += GetNum(i);
            }

            return number;
        }

        private static int GetNum(int i)
        {
            int count = 0;
            while (i > 0)
            {
                if (i % 10 == 1)
                    count++;
                i = i / 10;
            }

            return count;
        }

        [Fact]
        public void Test1()
        {
            for (int i = 0; i <= 3000; i++)
            {
                Assert.Equal(GetResultByBruteForce(i), CountOne.CountOneResult(i));
            }
        }

        [Fact]
        public void Test2()
        {
            for (int i = 3001; i <= 6000; i++)
            {
                Assert.Equal(GetResultByBruteForce(i), CountOne.CountOneResult(i));
            }
        }

        [Fact]
        public void Test3()
        {
            for (int i = 6001; i <= 8000; i++)
            {
                Assert.Equal(GetResultByBruteForce(i), CountOne.CountOneResult(i));
            }
        }

        [Fact]
        public void Test4()
        {
            for (int i = 8001; i <= 11111; i++)
            {
                Assert.Equal(GetResultByBruteForce(i), CountOne.CountOneResult(i));
            }
        }
    }
}
