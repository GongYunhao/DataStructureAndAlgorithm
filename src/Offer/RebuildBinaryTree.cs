using System;
using CommonModels;

namespace Offer
{
    public sealed class RebuildBinaryTree
    {
        public static BinaryTreeNode<int> Execute(int[] preorderResult, int[] inorderResult)
        {
            if (preorderResult == null || inorderResult == null || preorderResult.Length != inorderResult.Length || preorderResult.Length == 0)
                throw new ArgumentException("The input arrays are illegal");

            BinaryTreeNode<int> root = null;

            try
            {
                root = RebuildRecursively(preorderResult, inorderResult, 0, preorderResult.Length - 1,
                    0, inorderResult.Length - 1);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Can't rebuild tree from given two arrays", ae);
            }

            return root;
        }

        private static BinaryTreeNode<int> RebuildRecursively(int[] preorderResult, int[] inorderResult,
            int preorderStart, int preorderEnd, int inorderStart, int inorderEnd)
        {
            // 两种基准情况
            // 第一种表示当前递归循环中,目标数组区域内只有一个元素,可以直接返回一个节点(在树上显示为一个叶节点)
            // 第二种表示在上一轮递归循环中,进入了错误的分支(或者说没有必要考虑的分支),因为每一轮递归,如果不是基准情况,都会分别计算左子节点和右子节点.这种情况下,会传递无效的参数到本轮函数中,此时可以返回null对象,让上一轮递归可以正常结束(在树上显示为一个空位)
            if (preorderStart == preorderEnd)
            {
                // 需要验证两个数组内,对应的元素是否相等:相等才能添加为一个树节点
                if (preorderResult[preorderStart] == inorderResult[inorderStart])
                {
                    return new BinaryTreeNode<int>() { Value = preorderResult[preorderStart], Left = null, Right = null };
                }

                // 不相等的情况,抛出异常,表示输入的数据不能重建二叉树
                throw new ArgumentException("Elements in two arrays are different, can't add as new node");
            }
            if (preorderStart > preorderEnd)
                return null;

            // 定义根节点
            int rootValue = preorderResult[preorderStart];
            BinaryTreeNode<int> root = new BinaryTreeNode<int>() { Value = rootValue };

            // 在中序遍历数组中,获取根节点对应元素所在的序号
            int indexForRootNode = GetIndex(inorderResult,rootValue, inorderStart, inorderEnd);// 限定数组的有效区域
            int leftChildLength = indexForRootNode - inorderStart;// 限定有效区域后数组左子树对应的数组长度就不可能小于0

            // 重建左右子树,并连接到根节点上
            // 用原始数据+偏移量避免生成过多的临时对象
            root.Left = RebuildRecursively(preorderResult, inorderResult,
                preorderStart + 1, preorderStart + leftChildLength,
                inorderStart, indexForRootNode - 1);
            root.Right = RebuildRecursively(preorderResult, inorderResult,
                preorderStart + leftChildLength + 1, preorderEnd,
                indexForRootNode + 1, inorderEnd);

            return root;
        }

        private static int GetIndex(int[] array, int targetValue, int inorderStart, int inorderEnd)
        {
            for (int i = inorderStart; i <= inorderEnd; i++)
            {
                if (array[i] == targetValue)
                    return i;
            }

            throw new ArgumentException("Can't find target value in the given array");
        }
    }
}
