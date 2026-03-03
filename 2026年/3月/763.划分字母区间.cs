/*
 * @lc app=leetcode.cn id=763 lang=csharp
 *
 * [763] 划分字母区间
 */

// @lc code=start
public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        // 1. 记录每个字符最后出现的位置
        var lastIndex = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i]] = i;
        }

        // 2. 划分区间
        var result = new List<int>();
        int start = 0, end = 0;
        for (int i = 0; i < s.Length; i++)
        {
            end = Math.Max(end, lastIndex[s[i]]); // 更新当前区间的结束位置
            if (i == end)
            {
                result.Add(end - start + 1);
                start = i + 1; // 更新下一个区间的起始位置
            }
        }
        return result;
    }
}
// @lc code=end

