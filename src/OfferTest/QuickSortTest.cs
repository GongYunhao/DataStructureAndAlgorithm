using System;
using CommonModels;
using Offer;
using Xunit;

namespace OfferTest
{
    public class QuickSortTest
    {
        [Fact]
        public void test()
        {
            var result = new QuickSort().ExecuteSort(new[] { 9, 5, 4, 7, 8, 2, 3, 6, 4, 1 });
            Assert.Equal(10, result.Length);

            Assert.True(result.ContainsSameElement(new[] { 1, 2, 3, 4, 4, 5, 6, 7, 8, 9 }));
        }

        [Fact]
        public void testWithRandomData()
        {
            int[] array = new int[30000];
            Random r = new Random();
            for (int i = 0; i < 30000; i++)
                array[i] = r.Next(0, 100000);

            var result = new QuickSort().ExecuteSort(array);
            Assert.Equal(30000, result.Length);
            Assert.True(result.ContainsSameElement(array));

            for (int i = 0; i < 29999; i++)
            {
                Assert.True(result[i] <= result[i + 1]);
            }
        }
    }
}
