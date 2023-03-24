using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grind75.InvertBinaryTree;

namespace Grind75.Week4
{
    internal class ValidateBinarySearchTree
    {
        // checking against boundries Up-Down
        public bool IsValidBST(TreeNode root)
        {
            return ValidateRecursive(root, Int64.MinValue, Int64.MaxValue);
        }

        private bool ValidateRecursive(TreeNode node, Int64 left, Int64 right)
        {
            if (node == null)
                return true;

            if (! (node.val > left && node.val < right))
                return false;

            return ValidateRecursive(node.left, left, node.val) && ValidateRecursive(node.right, node.val, right);
        }



        // First try using sets. Down-Up
        public bool IsValidBSTFirst(TreeNode root)
        {
            return ValidateRecursiveSets(root, out _);
        }

        private bool ValidateRecursiveSets(TreeNode node, out HashSet<int> set)
        {
            if (node == null)
            {
                set = new HashSet<int>();
                return true;
            }

            var leftValidation = ValidateRecursiveSets(node.left, out HashSet<int> left);
            var rightValidation = ValidateRecursiveSets(node.right, out HashSet<int> right);
            if (!(leftValidation && rightValidation))
            {
                set = null;
                return false;
            }

            bool res = !(left.Any(x => x >= node.val) || right.Any(x => x <= node.val));

            left.UnionWith(right);
            left.Add(node.val);
            set = left;
            return res;
        }
    }
}
