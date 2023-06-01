using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week3
{
    internal class CloneGraphClass
    {
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            var nodeDict = new Dictionary<Node, Node>(); // key: origial node, value: clone
            return ProcessNode(node, nodeDict);
        }

        private Node ProcessNode(Node node, Dictionary<Node, Node> dict)
        {
            Node clonedNode;
            if (dict.ContainsKey(node))
            {
                clonedNode = dict[node];
            }
            else
            {
                clonedNode = new Node(node.val);
                dict.Add(node, clonedNode);

                foreach (var nextNode in node.neighbors)
                {
                    clonedNode.neighbors.Add(ProcessNode(nextNode, dict));
                }
            }

            return clonedNode;
        }
    }
}
