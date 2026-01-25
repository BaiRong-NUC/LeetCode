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
        List<int[]> res = new List<int[]>();
        // 按区间起始位置降序
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        int currentIndex = 0;
        while (currentIndex < intervals.Length)
        {
            int start = intervals[currentIndex][0];
            int end = intervals[currentIndex][1];
            // 寻找可以合并的区间
            for (int i = currentIndex + 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= end)
                {
                    end = Math.Max(end, intervals[i][1]);
                    currentIndex = i;
                }
            }
            // 合并区间加入结果集
            res.Add(new int[] { start, end });
            currentIndex++;
        }
        return res.ToArray();
    }
}
// @lc code=end

