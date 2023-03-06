using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75.Week2
{
    internal class MaximumDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);

            return Math.Max(left, right) + 1;
        }
    }
}
