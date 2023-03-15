using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    internal class Trie
    {
        private Dictionary<char,Node> _nodes;

        public Trie()
        {
            _nodes = new Dictionary<char, Node> ();
        }

        public void Insert(string word)
        {
            Dictionary<char, Node> nodeDict = _nodes;
            foreach (char c in word)
            {
                if (!nodeDict.TryGetValue(c, out Node currNode))
                {
                    var addNode = new Node();
                    nodeDict.Add(c, addNode);
                    nodeDict = addNode.neighbors;
                }
                else
                {
                    nodeDict = currNode.neighbors;
                }
            }

            if (!nodeDict.ContainsKey('\n'))
                nodeDict.Add('\n', new Node());
        }

        public bool Search(string word)
        {
            Dictionary<char, Node> nodeDict = _nodes;
            foreach (char c in word)
            {
                if (!nodeDict.TryGetValue(c, out Node currNode))
                    return false;
                else
                    nodeDict = currNode.neighbors;
            }

            if (!nodeDict.ContainsKey('\n'))
                return false;
            
            return true;
        }

        public bool StartsWith(string prefix)
        {
            Dictionary<char, Node>  nodeDict = _nodes;
            foreach (char c in prefix)
            {
                if (!nodeDict.TryGetValue(c, out Node currNode))
                    return false;
                else
                    nodeDict = currNode.neighbors;
            }

            return true;
        }


        private class Node
        {
            public Dictionary<char, Node> neighbors;

            public Node()
            {
                neighbors = new Dictionary<char, Node>();
            }
        }
    }
}
