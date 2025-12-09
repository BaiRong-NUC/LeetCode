using System.Collections.Generic;

/*
 * @lc app=leetcode.cn id=76 lang=csharp
 *
 * [76] 最小覆盖子串
 */

// @lc code=start
public class Solution
{
    public string MinWindow(string s, string t)
    {
        // 滑动窗口
        Dictionary<char, int> need = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (need.ContainsKey(c))
                need[c]++;
            else
                need[c] = 1;
        }
        int left = 0;
        int right = 0; // [left, right]
        int start = 0; // 记录最小覆盖子串的起始索引
        int minLen = int.MaxValue; // 记录最小覆盖子串的长度
        int valid = 0; // 记录满足need条件的字符个数
        while (right < s.Length)
        {
            char ch = s[right]; // ch是要进入窗口的字符
            right++; // 窗口右移

            // 记录窗口符合need的字符
            if (need.ContainsKey(ch))
            {
                window[ch] = window.ContainsKey(ch) ? window[ch] + 1 : 1;
                if (window[ch] == need[ch])
                    valid++;
            }

            // 收缩左侧窗口
            while (valid == need.Count)
            {
                // 已经找到一个覆盖子串, 更新最小覆盖子串
                if (right - left < minLen)
                {
                    start = left;
                    minLen = right - left;
                }
                char chd = s[left]; // chd是要移出窗口的字符
                left++; // 窗口左移
                if (need.ContainsKey(chd))
                {
                    if (window[chd] == need[chd])
                        valid--; // 减少了一个在need中的字符, valid减1
                    window[chd]--;
                }
            }
        }
        return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
    }
}
// @lc code=end

