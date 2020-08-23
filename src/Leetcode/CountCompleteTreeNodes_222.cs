using System;
using CommonModels;

namespace Leetcode
{
    public class CountCompleteTreeNodes_222
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxHeight = GetMaxHeight(root);

            int left = 0;
            int right = (int)Math.Pow(2, maxHeight - 1) - 1;
            int mask = (right + 1) >> 1;

            if (HasLeafOnRoute(root, right, mask))
            {
                return (int)Math.Pow(2, maxHeight) - 1;
            }

            while (left < right - 1)
            {
                int middle = (left + right) >> 1;
                if (HasLeafOnRoute(root, middle, mask))
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return (int)Math.Pow(2, maxHeight - 1) - 1 + right;
        }

        private bool HasLeafOnRoute(TreeNode root, int routeInt, int mask)
        {
            var currNode = root;
            while (mask > 0)
            {
                if ((routeInt & mask) == 0)
                {
                    currNode = currNode.left;
                }
                else
                {
                    currNode = currNode.right;
                }

                mask >>= 1;
            }

            return currNode != null;
        }

        private int GetMaxHeight(TreeNode root)
        {
            int height = 0;
            while (root != null)
            {
                height++;
                root = root.left;
            }
            return height;
        }
    }
}
