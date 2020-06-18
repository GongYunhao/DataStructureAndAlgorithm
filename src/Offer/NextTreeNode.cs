using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Offer
{
    public class NextTreeNode
    {
        public static BinaryTreeNode<char> FindNext(BinaryTreeNode<char> node)
        {
            if (node == null)
                throw new ArgumentNullException("Input node can't be null");

            BinaryTreeNode<char> result = null;
            // 如果当前节点有右子节点,则查找右子树中最"靠左"的节点(也就是查看右子节点是否有左子节点)
            // 如果没有右子节点,则向上寻找第一个符合条件的节点:该节点是其父节点的左子节点,这个父节点就是寻找的目标;当遍历到父节点都没有找到符合条件的节点时,返回null
            if (node.Right == null)
            {
                BinaryTreeNode<char> currentNode = node;
                // 持续向上遍历节点,查看当前节点是不是其父节点的左子节点,直到寻找到目标节点/遍历到达根节点
                while (currentNode != currentNode.Parent.Left)
                {
                    currentNode = currentNode.Parent;
                    if(currentNode.Parent == null)
                        break;// currentNode指针移动到根节点,表明没有符合条件的节点
                }

                result = currentNode.Parent;// 此处需要预设条件:根节点的Parent属性为null
            }
            else
            {
                BinaryTreeNode<char> currentNode = node.Right;
                while (currentNode.Left != null)
                    currentNode = currentNode.Left;
                result = currentNode;
            }

            return result;
        }
    }
}
