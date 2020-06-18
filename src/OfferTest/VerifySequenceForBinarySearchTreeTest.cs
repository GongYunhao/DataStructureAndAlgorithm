using System;
using Offer;
using Xunit;

namespace OfferTest
{
    public class VerifySequenceForBinarySearchTreeTest
    {
        [Fact]
        public void NormalInput()
        {
            Assert.True(VerifySequenceForBinarySearchTree.Verify(new[] { 5, 7, 6, 9, 11, 10, 8 }));
            Assert.False(VerifySequenceForBinarySearchTree.Verify(new[] { 7, 4, 6, 5 }));
        }

        [Fact]
        public void BinarySearchTreeWithOnlyLeftChileNode()
        {
            Assert.True(VerifySequenceForBinarySearchTree.Verify(new[] { 30, 23, 22, 18, 11 }));
            Assert.False(VerifySequenceForBinarySearchTree.Verify(new[] { 30, 23, 22, 10, 11 }));
        }

        [Fact]
        public void BinarySearchTreeWithOnlyOneNode()
        {
            Assert.True(VerifySequenceForBinarySearchTree.Verify(new[] { 30 }));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => VerifySequenceForBinarySearchTree.Verify(null));
            Assert.False(VerifySequenceForBinarySearchTree.Verify(new int[0]));
        }
    }
}
