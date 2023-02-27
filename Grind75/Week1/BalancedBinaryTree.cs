using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75
{
    internal class BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            var depths = new List<int>();
            ProcessTree(root, depths);

            return depths.Max() - depths.Min() <= 1;
        }

        public void ProcessTree(TreeNode root, List<int> depths, int lvlCount = 0)
        {

            if (root?.right != null)
                ProcessTree(root.right, depths, lvlCount+1);
            if (root.left != null)
                ProcessTree(root.left, depths, lvlCount+1);

            else if (root.right == null && root.left == null)
            {
                depths.Add(lvlCount);
            }
        }
    }
}
