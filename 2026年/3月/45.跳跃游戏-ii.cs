/*
 * @lc app=leetcode.cn id=45 lang=csharp
 *
 * [45] 跳跃游戏 II
 */

// @lc code=start
public class Solution
{
    public int Jump(int[] nums)
    {
        int[] dp = new int[nums.Length]; // dp[i] 表示跳到第 i 个位置的最少跳跃次数
        dp[0] = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = int.MaxValue;
            for (int j = 0; j < i; j++)
            {
                if (j + nums[j] >= i) // 如果从位置 j 可以跳到位置 i
                    dp[i] = Math.Min(dp[i], dp[j] + 1);
            }
        }
        return dp[nums.Length - 1];
    }
}
// @lc code=end

