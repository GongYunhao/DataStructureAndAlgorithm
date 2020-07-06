using CommonModels;

namespace Leetcode
{
    public class SameTree_100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null)
                return q == null;

            return q != null
                && p.val == q.val
                && IsSameTree(p.left, q.left)
                && IsSameTree(p.right, q.right);
        }
    }
}
