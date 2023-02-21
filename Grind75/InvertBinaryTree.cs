using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    internal class InvertBinaryTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null || 
                (root.left == null && root.right == null)) // adding this extra condition gives slightly better speed
                return root;

            var dummy = root.right;
            root.right = InvertTree(root.left);
            root.left = InvertTree(dummy);

            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
