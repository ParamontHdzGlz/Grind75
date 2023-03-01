using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    class RansomNote
    {
        // simple, using LINQ
        public bool CanConstructSimple(string ransomNote, string magazine)
        {
            foreach (char currChar in ransomNote.Distinct())
            {
                if (ransomNote.Count(c => c == currChar) > magazine.Count(c => c == currChar))
                    return false;
            }

            return true;
        }

        // using Dict
        public bool CanConstruct(string ransomNote, string magazine)
        {
            // initialize alphabet dict
            var magazineLetters = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
                magazineLetters[c] = 0;

            foreach (char c in magazine)
                magazineLetters[c]++;

            // check if we have enough letter in magazine
            foreach (char c in ransomNote)
            {
                if (magazineLetters[c] == 0)
                    return false;
                else
                    magazineLetters[c]-- ;
            }

            return true;

        }
    }
}
