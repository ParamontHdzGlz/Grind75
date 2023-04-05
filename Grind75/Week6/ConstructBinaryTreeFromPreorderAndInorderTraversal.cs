using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0)
                return null;

            var res = new TreeNode(preorder[0]);
            int divIndex = Array.IndexOf(inorder, res.val);

            var inLeft = inorder.Take(divIndex).ToArray();
            var preLeft = preorder.Skip(1).Take(inLeft.Length).ToArray();
            res.left = BuildTree(preLeft, inLeft);

            var inRight = inorder.Skip(divIndex + 1).ToArray();
            var preRight = preorder.Skip(inLeft.Length + 1).ToArray();
            res.right = BuildTree(preRight, inRight);

            return res;
        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
        }
    }
}
