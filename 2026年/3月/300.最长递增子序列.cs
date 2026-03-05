/*
 * @lc app=leetcode.cn id=300 lang=csharp
 *
 * [300] 最长递增子序列
 */

// @lc code=start
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int[] dp = new int[nums.Length]; // dp[i]表示以nums[i]结尾的最长递增子序列长度
        dp[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp.Max();
    }
}
// @lc code=end

