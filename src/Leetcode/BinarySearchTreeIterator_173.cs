using System.Collections.Generic;
using CommonModels;

namespace Leetcode
{
    public class BSTIterator
    {
        private readonly Stack<TreeNode> _stack = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {
            _stack.Push(root);

            // 从根节点开始,将所有的左子节点压入堆栈
            PushAllLeftNodesToLeaf();
        }

        public int Next()
        {
            // 从栈顶弹出一个节点
            var node = _stack.Pop();

            if (node.right != null)
            {
                // 若新弹出节点拥有右子节点,则将该右子节点压入堆栈
                _stack.Push(node.right);
                // 并从该右子节点出发,循环将左子节点压入堆栈
                PushAllLeftNodesToLeaf();
            }

            return node.val;// 返回当前节点的值
            // 此时,堆栈顶端即为我们下一个需要访问的节点值

            // 此方法总体时间复杂度为O(1),即堆栈弹出元素的时间
            // 在弹出元素拥有右节点时,才需要需要进行循环操作,此时的时间复杂度平均为O(logN),并且随着方法的调用逐渐减少
            // 对于平衡的二叉树而言,调用时间会逐渐减少,然后突变升高,再减少(从根节点的左子树转移到右子树的过程比较耗时)
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        /// <summary>
        /// 从栈顶节点开始, 如果节点具有左子节点,则将左子节点一路压入堆栈
        /// </summary>
        private void PushAllLeftNodesToLeaf()
        {
            var currentNode = _stack.Peek();
            while (currentNode.left != null)
            {
                currentNode = currentNode.left;
                _stack.Push(currentNode);
            }
        }
    }
}
