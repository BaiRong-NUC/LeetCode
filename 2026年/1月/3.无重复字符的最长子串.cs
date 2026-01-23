/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        // 滑动窗口
        HashSet<char> window = new HashSet<char>();
        int left = 0, right = 0;
        int maxLength = 0;
        while (right < s.Length)
        {
            char ch = s[right];
            right++;
            // 如果字符已经在窗口中，收缩左边界
            while (window.Contains(ch))
            {
                char leftChar = s[left];
                left++;
                window.Remove(leftChar);
            }
            window.Add(ch);
            maxLength = Math.Max(maxLength, right - left);
        }
        return maxLength;
    }
}
// @lc code=end

