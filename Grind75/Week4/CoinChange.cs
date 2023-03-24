using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week4
{
    public class CoinChangeClass
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            var memo = new int[amount + 1];
            Array.Fill(memo, amount+1);
            memo[0] = 0;

            for (int currAmount =1; currAmount <= amount; currAmount++)
            {
                foreach (int coin in coins)
                {
                    if (currAmount - coin >= 0) 
                        memo[currAmount] = Math.Min(memo[currAmount], memo[currAmount - coin] + 1);
                }
            }

            return memo[amount] != amount + 1 ? memo[amount] : -1;
        }

            // First Try
        public int CoinChange1(int[] coins, int amount)
        {
            var memo = new Dictionary<int, int?>();
            memo.Add(0, 0);

            int? DFS(int residue)
            {
                if (memo.ContainsKey(residue))
                    return memo[residue];
                else if (residue < 0)
                    return null;

                foreach (var coin in coins)
                {
                    var val = DFS(residue - coin);
                    if (val.HasValue)
                    {
                        if (!memo.ContainsKey(residue))
                            memo[residue] = val + 1;
                        else
                            memo[residue] = Math.Min((int)memo[residue], (int)val + 1);
                    }
                }

                if (!memo.ContainsKey(residue))
                    memo.Add(residue, null);

                return memo[residue];
            }

            DFS(amount);

            return memo[amount] ?? -1;
        }
    }
}
