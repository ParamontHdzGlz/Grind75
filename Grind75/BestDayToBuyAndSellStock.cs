using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75
{
    internal class BestDayToBuyAndSellStock
    {

        public int MaxProfitBetter(int[] prices)
        {
            int bestBuyIndex = 0;
            int bestSellIndex = 1;
            int maxProfit = 0;

            while (bestSellIndex < prices.Length-1)
            {
                if (prices[bestBuyIndex] < prices[bestSellIndex])
                {
                    if (prices[bestSellIndex] - prices[bestBuyIndex] > maxProfit)
                        maxProfit = prices[bestSellIndex] - prices[bestBuyIndex];
                }
                else
                {
                    bestBuyIndex = bestSellIndex;
                }

                bestSellIndex++;
            }

            return maxProfit;
        }

        public int MaxProfitBase(int[] prices)
        {
            if (prices.Length < 2) return 0;

            int bestBuyIndex = 0;
            int bestSellIndex = 1;
            int maxProfit = prices[bestSellIndex] - prices[bestBuyIndex];

            for (int buyIndex = 0; buyIndex < prices.Length - 1; buyIndex++)
            {
                for (int sellIndex = buyIndex + 1; sellIndex < prices.Length; sellIndex++)
                {
                    if (prices[sellIndex] > prices[buyIndex])
                    {
                        if (prices[sellIndex] - prices[buyIndex] > maxProfit)
                        {
                            bestBuyIndex = buyIndex;
                            bestSellIndex = sellIndex;
                        }
                        maxProfit = prices[bestSellIndex] - prices[bestBuyIndex];
                    }

                }
            }

            return maxProfit > 0 ? maxProfit : 0;
        }
    }
}
