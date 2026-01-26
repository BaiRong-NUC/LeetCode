/*
 * @lc app=leetcode.cn id=621 lang=csharp
 *
 * [621] 任务调度器
 */

// @lc code=start
public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        int[] counts = new int[26];
        foreach (char task in tasks)
        {
            counts[task - 'A']++;
        }

        Array.Sort(counts);
        int maxCount = counts[25];
        int idleTime = (maxCount - 1) * n;

        // 填充其他任务
        for (int i = 24; i >= 0 && counts[i] > 0; i--)
        {
            idleTime -= Math.Min(counts[i], maxCount - 1); //每个任务最多可以填充 maxCount - 1 次（不能超过最大任务的间隔数）
        }

        idleTime = Math.Max(0, idleTime); // 如果空闲时间为负，说明任务可以完全填充，总时间就是任务总数
        return tasks.Length + idleTime;
    }
}
// @lc code=end

