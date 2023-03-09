using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75.Week3
{
    internal class BinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            ProcessNode(root, 0, result);

            return result;
        }

        private void ProcessNode(TreeNode node, int lvl, IList<IList<int>> list)
        {
            if (node == null)
                return;

            if (list.Count-1 < lvl)
                list.Add(new List<int> { node.val });
            else
                list[lvl].Add(node.val);

            ProcessNode(node.left, lvl + 1, list);
            ProcessNode(node.right, lvl + 1, list);
        }
    }
}
