using System;
using System.Collections.Generic;
using System.Text;
using CommonModels;

namespace Leetcode
{
    public class LowestCommonAncestorofaBinarySearchTree_235
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            int pVal = p.val, qVal = q.val;

            TreeNode currNode = root;

            while (currNode != null)
            {
                if (currNode.val > pVal && currNode.val > qVal)
                {
                    currNode = currNode.left;
                }
                else if (currNode.val < pVal && currNode.val < qVal)
                {
                    currNode = currNode.right;
                }
                else
                {
                    return currNode;
                }
            }

            return null;
        }
    }
}
