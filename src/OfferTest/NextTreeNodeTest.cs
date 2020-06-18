using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using CommonModels;
using Xunit;

namespace OfferTest
{
    public class NextTreeNodeTest
    {
        [Fact]
        public void RegularExampleTest()
        {
            BinaryTreeNode<char> root = new BinaryTreeNode<char>() { Value = 'a' };
            BinaryTreeNode<char> nodeb = new BinaryTreeNode<char>() { Value = 'b' };
            BinaryTreeNode<char> nodec = new BinaryTreeNode<char>() { Value = 'c' };
            BinaryTreeNode<char> noded = new BinaryTreeNode<char>() { Value = 'd' };
            BinaryTreeNode<char> nodee = new BinaryTreeNode<char>() { Value = 'e' };
            BinaryTreeNode<char> nodef = new BinaryTreeNode<char>() { Value = 'f' };
            BinaryTreeNode<char> nodeg = new BinaryTreeNode<char>() { Value = 'g' };
            BinaryTreeNode<char> nodeh = new BinaryTreeNode<char>() { Value = 'h' };
            BinaryTreeNode<char> nodei = new BinaryTreeNode<char>() { Value = 'i' };

            root.Left = nodeb;
            root.Right = nodec;
            nodeb.Left = noded;
            nodeb.Right = nodee;
            nodec.Left = nodef;
            nodec.Right = nodeg;
            nodee.Left = nodeh;
            nodee.Right = nodei;

            Assert.Equal(nodef, NextTreeNode.FindNext(root));
            Assert.Equal(nodeh, NextTreeNode.FindNext(nodeb));
            Assert.Equal(nodeg, NextTreeNode.FindNext(nodec));
            Assert.Equal(nodeb, NextTreeNode.FindNext(noded));
            Assert.Equal(nodei, NextTreeNode.FindNext(nodee));
            Assert.Equal(nodec, NextTreeNode.FindNext(nodef));
            Assert.Null(NextTreeNode.FindNext(nodeg));
            Assert.Equal(nodee, NextTreeNode.FindNext(nodeh));
            Assert.Equal(root, NextTreeNode.FindNext(nodei));
        }

        [Fact]
        public void NullInputTest()
        {
            Assert.Throws<ArgumentNullException>(() => NextTreeNode.FindNext(null));
        }
    }
}
