using System.Collections.Generic;
using CommonModels;

namespace Offer
{
    public class MirrorOfBinaryTree
    {
        public static void GetMirror(BinaryTreeNode<int> root)
        {
            if (root == null)
                return;

            // 使用递归
            //BinaryTreeNode<int> tmp = root.Left;
            //root.Left = root.Right;
            //root.Right = tmp;

            //GetMirror(root.Left);
            //GetMirror(root.Right);

            // 使用队列和while循环完成反转
            Queue<BinaryTreeNode<int>> queue = new Queue<BinaryTreeNode<int>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                BinaryTreeNode<int> currentRoot = queue.Dequeue();

                BinaryTreeNode<int> tmp = currentRoot.Left;
                currentRoot.Left = currentRoot.Right;
                currentRoot.Right = tmp;

                if (currentRoot.Left != null)
                    queue.Enqueue(currentRoot.Left);
                if (currentRoot.Right != null)
                    queue.Enqueue(currentRoot.Right);
            }
        }
    }
}
