/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子数组和
 */

// @lc code=start
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        // dp[i] 表示以 nums[i] 结尾的最大子数组和
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
        }
        return dp.Max();
    }
}
// @lc code=end

