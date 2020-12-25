using System.Collections.Generic;
using CommonModels;

namespace Leetcode
{
    public class KthSmallestElementOfBST_230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            var enumerator = ToInorder(root).GetEnumerator();

            while (k > 0)
            {
                enumerator.MoveNext();
                k--;
            }

            return enumerator.Current.val;
        }

        /// <summary>
        /// 获取二叉树的前序遍历结果
        /// </summary>
        private IEnumerable<TreeNode> ToInorder(TreeNode root)
        {
            if (root.left != null)
            {
                var leftChildren = ToInorder(root.left);
                foreach (var child in leftChildren)
                {
                    yield return child;// 获取左子树的迭代器,用yield return返回,作为上一层迭代器结果的一部分
                }
            }

            yield return root;

            if (root.right != null)
            {
                var rightChildren = ToInorder(root.right);
                foreach (var child in rightChildren)
                {
                    yield return child;
                }
            }
        }
    }
}
