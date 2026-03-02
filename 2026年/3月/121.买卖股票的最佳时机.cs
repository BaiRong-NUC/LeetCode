/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public class Solution
{
    // public int MaxProfit(int[] prices)
    // {
    //     int minPrice = int.MaxValue, maxProfit = 0;
    //     foreach (int price in prices)
    //     {
    //         minPrice = Math.Min(minPrice, price);
    //         maxProfit = Math.Max(maxProfit, price - minPrice);
    //     }
    //     return maxProfit;
    // }
    public int MaxProfit(int[] prices)
    {
        List<int> stack = new List<int>();// 单调递增栈
        // 插入哨兵位,保证栈能弹空
        prices = prices.Append(-1).ToArray();
        int maxProfit = 0;
        foreach (int price in prices)
        {
            while (stack.Count > 0 && stack.Last() > price)
            {
                maxProfit = Math.Max(maxProfit, stack.Last() - stack.First());
                stack.RemoveAt(stack.Count - 1);
            }
            stack.Add(price);
        }
        return maxProfit;
    }
}
// @lc code=end

