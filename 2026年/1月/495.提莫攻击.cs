/*
 * @lc app=leetcode.cn id=495 lang=csharp
 *
 * [495] 提莫攻击
 */

// @lc code=start
public class Solution
{
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        int totalDuration = 0;
        for (int i = 1; i < timeSeries.Length; i++)
        {
            totalDuration += Math.Min(timeSeries[i] - timeSeries[i - 1], duration);
        }
        // 处理最后一次攻击的持续时间
        if (timeSeries.Length > 0)
        {
            totalDuration += duration;
        }
        return totalDuration;
    }
}
// @lc code=end

