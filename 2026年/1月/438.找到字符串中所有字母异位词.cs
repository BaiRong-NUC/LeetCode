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
        List<int> result = new List<int>();
        if (s.Length < p.Length) return result;
        Dictionary<char, int> pCount = new Dictionary<char, int>();
        // 统计p中字符频次
        foreach (char ch in p)
        {
            if (!pCount.ContainsKey(ch))
                pCount[ch] = 0;
            pCount[ch]++;
        }
        Dictionary<char, int> windowCount = new Dictionary<char, int>();
        int left = 0, right = 0;
        int valid = 0; // 记录窗口中满足条件的字符个数
        while (right < s.Length)
        {
            char ch = s[right];
            right += 1;
            // 更新窗口数据
            if (pCount.ContainsKey(ch))
            {
                if (!windowCount.ContainsKey(ch))
                    windowCount[ch] = 0;
                windowCount[ch]++;
                if (windowCount[ch] == pCount[ch])
                    valid++;
            }
            if (valid == pCount.Count)
            {
                result.Add(left);
            }
            // 当窗口大小等于p的长度时，收缩左边界
            if (right - left >= p.Length)
            {
                char d = s[left];
                left += 1;
                // 更新窗口数据
                if (pCount.ContainsKey(d))
                {
                    if (windowCount[d] == pCount[d])
                        valid--;
                    windowCount[d]--;
                }
            }
        }
        return result;
    }
}
// @lc code=end

