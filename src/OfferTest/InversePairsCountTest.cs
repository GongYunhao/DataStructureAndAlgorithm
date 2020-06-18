using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class InversePairsCountTest
    {
        private int GetResultByBruteForce(int[] array)
        {
            int count = 0;
            for (int i = 0; i <= array.Length - 2; i++)
            {
                for (int j = i + 1; j <= array.Length - 1; j++)
                {
                    if (array[i] > array[j])
                        count++;
                }
            }

            return count;
        }

        private int[] GenerateArray(int length)
        {
            Random r = new Random();
            int[] array = new int[length];
            for (int i = 0; i <= length - 1; i++)
                array[i] = r.Next(0, 1500);
            return array;
        }

        [Fact]
        public void ExampleOnBook()
        {
            Assert.Equal(5, InversePairsCount.GetCount(new[] { 7, 5, 6, 4 }));
        }

        [Fact]
        public void TestWithSortedArray()
        {
            int[] array = GenerateArray(5000);
            Array.Sort(array);
            Assert.Equal(0, InversePairsCount.GetCount(array));
        }

        [Fact]
        public void TestWithReverselySortedArray()
        {
            int[] array = GenerateArray(5000);
            Array.Sort(array, (int a, int b) => b - a);
            Assert.Equal(GetResultByBruteForce(array), InversePairsCount.GetCount(array));
        }

        [Fact]
        public void TestWithRandomArray()
        {
            int[] array = GenerateArray(5000);
            Assert.Equal(GetResultByBruteForce(array), InversePairsCount.GetCount(array));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => InversePairsCount.GetCount(null));
            Assert.Equal(0, InversePairsCount.GetCount(new int[0]));
        }
    }
}
