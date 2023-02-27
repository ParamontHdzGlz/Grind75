using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75
{
    internal class LowestCommonAncestorOfABinarySearchTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            int maxValue = (p.val > q.val) ? p.val : q.val;
            int minValue = (p.val > q.val) ? q.val : p.val;
            TreeNode currentNode = root;

            do
            {
                if (currentNode.val > maxValue)
                    currentNode = currentNode.right;
                else if (currentNode.val < minValue)
                    currentNode = currentNode.left;
                else
                    return currentNode;
            }while (currentNode != null);

            return null;

        }
    }
}
