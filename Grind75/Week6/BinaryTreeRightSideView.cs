using Grind75.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75.Week6
{
    internal class BinaryTreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var res = new List<int> ();

            void RightDFS(TreeNode node, int lvl)
            {
                if (node == null)
                    return;

                if (lvl == res.Count)
                    res.Add(node.val);

                RightDFS(node.right, lvl + 1);
                RightDFS(node.left, lvl + 1);
            }

            RightDFS(root, 0);

            return res;
        }
    }
}
