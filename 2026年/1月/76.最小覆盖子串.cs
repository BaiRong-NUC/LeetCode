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
        Dictionary<char, int> dictT = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (dictT.ContainsKey(c))
            {
                dictT[c]++;
            }
            else
            {
                dictT[c] = 1;
            }
        }
        int vaild = 0;
        Dictionary<char, int> window = new Dictionary<char, int>();
        string ret = "";
        int left = 0, right = 0;
        while (right < s.Length)
        {
            char c = s[right++];
            if (dictT.ContainsKey(c))
            {
                if (window.ContainsKey(c))
                {
                    window[c]++;
                }
                else
                {
                    window[c] = 1;
                }
                if (window[c] == dictT[c])
                {
                    vaild++;
                }
            }
            // 收缩左侧窗口
            while (vaild == dictT.Count)
            {
                // 在收缩过程中更新最小窗口
                if (ret == "" || right - left < ret.Length)
                {
                    ret = s.Substring(left, right - left);
                }
                char d = s[left++];
                if (dictT.ContainsKey(d))
                {
                    if (window[d] == dictT[d])
                    {
                        vaild--;
                    }
                    window[d]--;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

