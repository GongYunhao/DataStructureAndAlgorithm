using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class ChangeOrderTest
    {
        [Fact]
        public void Test()
        {
            int[] array = new int[300];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next(500);

            Func<int, bool> condition = i => (i % 3) == 0;// 传入一个int,如果是奇数,返回true
            ChangeOrder.Execute(array, condition);// 用委托形式封装条件语句,这样可以让用户自己定义规则(这里指怎样的值会被分到前半部分去)
            //ChangeOrder.Execute(array);

            bool isOverLine = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (!condition(array[i]))
                    isOverLine = true;

                Assert.True(isOverLine ^ condition(array[i]));
            }
        }

        [Fact]
        public void SpecialTest()
        {
            ChangeOrder.Execute(null);
            ChangeOrder.Execute(new int[0]);

            ChangeOrder.Execute(new int[] { 1 });
        }
    }
}
