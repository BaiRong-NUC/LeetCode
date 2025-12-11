/*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 */

// @lc code=start
public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        // 滑动窗口
        List<int> rets = new List<int>();
        Dictionary<char, int> need = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();
        // 需要的字符及其数量
        foreach (char c in p)
        {
            if (!need.ContainsKey(c))
            {
                need[c] = 0;
            }
            need[c] += 1;
        }
        int left = 0; int right = 0;
        int valid = 0;
        while (right < s.Length)
        {
            // c 是将移入窗口的字符
            char c = s[right];
            right += 1;
            // 进行窗口内数据的一系列更新
            if (need.ContainsKey(c))
            {
                if (!window.ContainsKey(c))
                {
                    window[c] = 0;
                }
                window[c] += 1;
                // 这个字符数量符合需求了
                if (window[c] == need[c])
                {
                    valid += 1;
                }
            }

            if (valid == need.Count)
            {
                // 判断是否符合条件
                if (right - left == p.Length)
                {
                    rets.Add(left);
                }
            }

            // 收缩左窗口
            while (right - left >= p.Length)
            {
                // d 是将移出窗口的字符
                char d = s[left];
                left += 1;
                // 进行窗口内数据的一系列更新
                if (need.ContainsKey(d))
                {
                    if (window[d] == need[d])
                    {
                        valid -= 1;
                    }
                    window[d] -= 1;
                }
            }
        }

        return rets;
    }
}
// @lc code=end

