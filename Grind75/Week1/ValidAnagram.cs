using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    internal class ValidAnagram
    {

        public bool IsAnagram(string s, string t)
        {

            var originalDict = s
                .GroupBy(s => s)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach(char c in t)
            {
                if (originalDict.ContainsKey(c))
                    originalDict[c]--;
                else
                    return false;
            }

            return !originalDict.Values.Where(x => x < 0).Any() &&
                originalDict.Values.Sum() == 0;
        }


        ///First Try
        public bool IsAnagramFirstTry(string s, string t)
        {
            var sDict = BuildDictionary(s);
            var tDict = BuildDictionary(t);

            return sDict.Count == tDict.Count && !sDict.Except(tDict).Any();

        }

        public Dictionary<char, int> BuildDictionary(string s)
        {
            var retDict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (retDict.ContainsKey(c))
                    retDict[c]++;
                else
                    retDict.Add(c, 1);
            }

            return retDict;
        }

    }
}
