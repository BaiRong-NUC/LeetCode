/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length < 2) return s;

        // dp[i][j]代表s从i到j是否为回文串
        bool[,] dp = new bool[s.Length, s.Length];
        // 初始化：所有长度为1的子串都是回文串
        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = true;
        }
        int maxLen = 1;
        int begin = 0;
        for (int length = 2; length <= s.Length; length++)
        {
            for (int left = 0; left < s.Length; left++)
            {
                // [left, left + length - 1] 
                int right = left + length - 1;
                if (right >= s.Length) break;

                if (s[left] != s[right])
                {
                    dp[left, right] = false;
                }
                else
                {
                    if (length < 3)
                    {
                        // 长度为2且两端相等则为回文串
                        dp[left, right] = true;
                    }
                    else
                    {
                        dp[left, right] = dp[left + 1, right - 1];
                    }
                }

                if (dp[left, right] == true && length > maxLen)
                {
                    maxLen = length;
                    begin = left;
                }
            }
        }
        return s.Substring(begin, maxLen);
    }
}
// @lc code=end

