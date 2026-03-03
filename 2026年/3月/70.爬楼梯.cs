/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] dp = new int[n + 1]; // dp[i] 表示爬到第 i 级台阶的方法数
        dp[0] = 1;
        dp[1] = 1; // 爬到第 1 级台阶的方法数
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
}
// @lc code=end

