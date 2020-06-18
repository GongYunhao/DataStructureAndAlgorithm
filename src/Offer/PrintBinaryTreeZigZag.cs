using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Offer
{
    public class PrintBinaryTreeZigZag
    {
        public static string Print(BinaryTreeNode<int> root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root), "The root of binary tree can't be null");

            // 设立两个堆栈,其中一个在消耗元素的同时,往另一个中添加元素
            // 一个堆栈消耗完毕,开始消耗另一个堆栈,同时如果有新元素需要添加,就添加到之前已经消耗完毕的堆栈中,直到另一个堆栈消耗完毕,再调转回来
            Stack<BinaryTreeNode<int>> stack1 = new Stack<BinaryTreeNode<int>>();
            Stack<BinaryTreeNode<int>> stack2 = new Stack<BinaryTreeNode<int>>();

            StringBuilder sb = new StringBuilder();
            bool leftToRight = true;
            stack1.Push(root);

            // 当两个堆栈全部清空的时候,循环才能结束
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                if (leftToRight)
                {
                    var currentNode = stack1.Pop();
                    sb.Append(currentNode.Value).Append(",");

                    // 当前层从左到右遍历时,要考虑到下一层是从右往左遍历的,所以要先将左子节点压入堆栈,再压入右子节点
                    if (currentNode.Left != null)
                        stack2.Push(currentNode.Left);
                    if (currentNode.Right != null)
                        stack2.Push(currentNode.Right);

                    // 当前堆栈清空以后,说明当前层级遍历结束,修改标志,改变遍历方向
                    // 如果是实际输出到显示屏上,可以在此加入换行符号
                    if (stack1.Count == 0)
                        leftToRight = false;
                }
                else
                {
                    var currentNode = stack2.Pop();
                    sb.Append(currentNode.Value).Append(",");

                    if (currentNode.Right != null)
                        stack1.Push(currentNode.Right);
                    if (currentNode.Left != null)
                        stack1.Push(currentNode.Left);

                    if (stack2.Count == 0)
                        leftToRight = true;
                }
            }

            return sb.ToString(0, sb.Length - 1);// 去掉最后一个逗号
        }
    }
}
