using CommonModels;

namespace Leetcode
{
    public class BinaryTreeMaximumPathSum_124
    {
        /// <summary>
        /// 在整个计算过程中,暂存最大的路径数值之和<br/>
        /// 当计算完成时,此变量中保存的即为整个树结构对应的算法结果
        /// </summary>
        private int result;

        public int MaxPathSum(TreeNode root)
        {
            result = root.val; // 根据题目,根节点不能为Null,所以可以使用根节点的值作为初始值

            MaxPathSumRecursively(root);

            return result;
        }

        private int MaxPathSumRecursively(TreeNode subTreeRoot)
        {
            // 分别计算左子树和右子树对应的最大数值
            // 若不包含左右子树,则变量赋值为Null
            int? left = subTreeRoot.left == null ? null : (int?)MaxPathSumRecursively(subTreeRoot.left);
            int? right = subTreeRoot.right == null ? null : (int?)MaxPathSumRecursively(subTreeRoot.right);

            // 比对左右子树返回结果,将最大值存入result变量
            ReplaceResultWithLarger(left);
            ReplaceResultWithLarger(right);

            // 如果根节点同时拥有左右子树,那么存在一种可能的路径
            // 即路径从左子树出发,经过根节点,通向右子树内部
            // 这种情况需要计算其路径的最大值,并与result变量比对
            // 但是这种路径不可能继续延伸到根节点的父节点,所以无函数返回值
            if(HasAboveZeroValue(left) && HasAboveZeroValue(right))
            {
                ReplaceResultWithLarger(subTreeRoot.val + left.Value + right.Value);
            }

            // 接下来计算路径可能通向父节点的情况
            // 即 根节点自身 或 左子树->根节点 或 右子树->根节点(左右子树的返回值必须大于0才能参与比对)
            // 这几种情况不仅需要与result变量比对,还需要返回值,让父节点做进一步处理
            if (HasAboveZeroValue(left) && HasAboveZeroValue(right))
            {
                // 如果根节点同时拥有左右子树,那么我们选取其中最大的一条,加上根节点作为可能的路径
                var pathVal = subTreeRoot.val + (left.Value > right.Value ? left.Value : right.Value);
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
            else if (HasAboveZeroValue(right))
            {
                // 如果根节点仅拥有右子树
                var pathVal = subTreeRoot.val + right.Value;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
            else if (HasAboveZeroValue(left))
            {
                // 如果根节点仅拥有左子树
                var pathVal = subTreeRoot.val + left.Value;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
            else
            {
                // 仅根节点自身返回给父节点
                var pathVal = subTreeRoot.val;
                ReplaceResultWithLarger(pathVal);
                return pathVal;
            }
        }

        private void ReplaceResultWithLarger(int? newVal)
        {
            if (!newVal.HasValue)
                return;

            if (newVal.Value > result)
                result = newVal.Value;
        }

        /// <summary>
        /// 判断是否有子树<br/>
        /// 并且子树的返回值必须大于0才有进一步判断的意义
        /// </summary>
        private bool HasAboveZeroValue(int? val)
        {
            return val.HasValue && val.Value > 0;
        }
    }
}
