/*
 * @lc app=leetcode.cn id=56 lang=csharp
 *
 * [56] 合并区间
 */

// @lc code=start
public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        List<int[]> merged = new List<int[]>();

        foreach (var interval in intervals)
        {
            // 如果 merged 为空，或者当前区间的起点大于 merged 列表中最后一个区间的终点
            if (merged.Count == 0 || merged[merged.Count - 1][1] < interval[0])
            {
                merged.Add(interval);
            }
            else
            {
                // 有重叠，更新最后一个区间的终点为两者的最大值
                merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], interval[1]);
            }
        }

        return merged.ToArray();
    }
}
// @lc code=end

