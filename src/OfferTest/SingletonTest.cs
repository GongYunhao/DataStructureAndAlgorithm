using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Offer;

namespace OfferTest
{
    public class SingletonTest
    {
        [Fact]
        public void SingletonWithDoubleCheckTest()
        {
            SingletonWithDoubleCheck s1 = SingletonWithDoubleCheck.Instance;
            SingletonWithDoubleCheck s2 = SingletonWithDoubleCheck.Instance;
            SingletonWithDoubleCheck s3 = SingletonWithDoubleCheck.Instance;

            Assert.NotNull(s1);
            Assert.Equal(s1, s2);
            Assert.Equal(s1, s3);
        }

        [Fact]
        public void SingletonUsingStaticFieldTest()
        {
            SingletonUsingStaticField s1 = SingletonUsingStaticField.Instance;
            SingletonUsingStaticField s2 = SingletonUsingStaticField.Instance;
            SingletonUsingStaticField s3 = SingletonUsingStaticField.Instance;

            Assert.NotNull(s1);
            Assert.Equal(s1, s2);
            Assert.Equal(s1, s3);
        }

        [Fact]
        public void SingletonWithNestedClassTest()
        {
            SingletonWithNestedClass s1 = SingletonWithNestedClass.Instance;
            SingletonWithNestedClass s2 = SingletonWithNestedClass.Instance;
            SingletonWithNestedClass s3 = SingletonWithNestedClass.Instance;

            Assert.NotNull(s1);
            Assert.Equal(s1, s2);
            Assert.Equal(s1, s3);
        }
    }
}
