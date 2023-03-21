using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    public class AccountsMergeClass
    {
        private class DSU
        {
            private int[] _parents;

            public DSU(int size)
            {
                _parents = Enumerable.Range(0, size).ToArray();
            }

            public int Find(int node)
            {
                if (node == _parents[node])
                    return node;

                return Find(_parents[node]);
            }


            public void Union(int node1, int node2)
            {
                var parentNode1 = Find(node1);
                var parentNode2 = Find(node2);

                if (parentNode1 != parentNode2)
                    _parents[parentNode2] = parentNode1;
            }
        }


        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var email_accountIndex = new Dictionary<string, int>();
            var accountDSU = new DSU(accounts.Count);

            for (int accountIdx = 0; accountIdx < accounts.Count; accountIdx++)
            {
                for (int emailIdx = 1 ; emailIdx < accounts[accountIdx].Count; emailIdx++)
                {
                    var email = accounts[accountIdx][emailIdx];
                    if (email_accountIndex.ContainsKey(email))
                        accountDSU.Union(email_accountIndex[email], accountIdx);
                    else
                        email_accountIndex.Add(email, accountIdx);
                }
            }

            var merge = new Dictionary<int, List<string>>();
            foreach (var kvp in email_accountIndex)
            {
                if (!merge.ContainsKey(accountDSU.Find(kvp.Value)))
                    merge.Add(accountDSU.Find(kvp.Value), new List<string> { kvp.Key });
                else
                    merge[accountDSU.Find(kvp.Value)].Add(kvp.Key);
            }

            var res = new List<IList<string>>(merge.Count);
            foreach(var kvp in merge)
            {
                res.Add( new List<string> { accounts[kvp.Key][0] });
                kvp.Value.Sort(); // sort on C# not working as expected by leetcode ):
                ((List<string>)res[res.Count-1]).AddRange(kvp.Value);
            }

            return res;
        }
    }
}
