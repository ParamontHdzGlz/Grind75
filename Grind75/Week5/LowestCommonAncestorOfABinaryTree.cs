using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75.Week5
{
    internal class LowestCommonAncestorOfABinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode LCA = null;
            ParseTreeDFS(root, p.val, q.val, ref LCA);
            return LCA;
        }

        private bool ParseTreeDFS(TreeNode root, int pVal, int qVal, ref TreeNode LCA)
        {
            if (LCA != null)
                return false;

            if (root == null)
                return false;

            bool left;
            bool right;

            if (root.val == pVal || root.val == qVal)
            {
                left = ParseTreeDFS(root.left, pVal, qVal, ref LCA);
                right = ParseTreeDFS(root.right, pVal, qVal, ref LCA);

                if (left || right)
                    LCA = root;

                return true;
            }
            else
            {
                left = ParseTreeDFS(root.left, pVal, qVal, ref LCA);
                right = ParseTreeDFS(root.right, pVal, qVal, ref LCA);

                if (left && right)
                    LCA = root;

                return left || right;
            }    
   
        }
    }
}
