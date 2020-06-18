using CommonModels;

namespace Offer
{
    public class DoesTreeAContainsTreeB
    {
        public static bool HasSubtree(BinaryTreeNode<int> treeA, BinaryTreeNode<int> treeB)
        {
            bool result = false;

            if (treeA != null && treeB != null)
            {
                // 如果根节点值一致,则需要查看以A为根节点的子树是否包含了B
                if (treeA.Value == treeB.Value)
                    result = IfContains(treeA, treeB);
                if (!result)
                    result = HasSubtree(treeA.Left, treeB);// 根节点值不一致,首先看左子树和B的关系
                if (!result)
                    result = HasSubtree(treeA.Right, treeB);// 如果左子树依然不包含B,那么回去看右子树是否包含
            }

            return result;// 只要有一个条件满足,整个函数就可以返回true
        }

        // 判断以treeA节点为根的树,是否包含treeB
        // 展开来说,就是B树中的所有节点,A树中都有,而且位置关系一致(当然A树中可以有更多的元素,这不影响结果)
        private static bool IfContains(BinaryTreeNode<int> treeA, BinaryTreeNode<int> treeB)
        {
            if (treeB == null)
                return true;// 当b节点为null时,无论如何b树都不会比a树的节点更多,所以返回true
            if (treeA == null)
                return false;// 当b不为null,且a为null时,b的节点比a多了,所以返回false

            if (treeA.Value != treeB.Value)
                return false;// 当两者值不一致时,两棵树也不会相同,返回false

            // 上面的条件全部通过,接下来判断子节点,以及子节点所形成的子树是否形成包含关系
            // 例如这一轮中,b已经是叶节点了,则它的子节点都是null,那么不论a的子节点如何,返回的结果都是true
            return IfContains(treeA.Left, treeB.Left) &&
                   IfContains(treeA.Right, treeB.Right);
        }
    }
}
