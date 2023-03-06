using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75.Week2
{
    internal class DiameterOfBinaryTreeClass
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int diameter = 0;
            LongestBranchLength(root, ref diameter);

            return diameter;
        }

        private int LongestBranchLength(TreeNode node, ref int diameter)
        {
            if (node == null)
                return 0;

            int left = LongestBranchLength(node.left, ref diameter);
            int right = LongestBranchLength(node.right, ref diameter);

            diameter = Math.Max(diameter, left + right);

            return Math.Max(left, right) + 1;
        }
    }
}
