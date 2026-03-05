/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 */

// @lc code=start
public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1]; // dp[i]表示金额i的最少硬币数量
        dp[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            dp[i] = int.MaxValue;
            foreach (int coin in coins)
            {
                if (i - coin >= 0 && dp[i - coin] != int.MaxValue)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }
        return dp[amount] == int.MaxValue ? -1 : dp[amount];
    }
}
// @lc code=end

