/*
 * @lc app=leetcode.cn id=139 lang=csharp
 *
 * [139] 单词拆分
 */

// @lc code=start
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        int[] dp = new int[s.Length + 1]; // dp[i]表示s[0..i-1]是否可以被wordDict拆分
        dp[0] = 1; // 空字符串可以被拆分
        for (int i = 1; i <= s.Length; i++)
        {
            foreach (string word in wordDict)
            {
                int len = word.Length;
                if (i - len >= 0 && dp[i - len] == 1 && s.Substring(i - len, len) == word)
                {
                    dp[i] = 1;
                    break;
                }
            }
        }
        return dp[s.Length] == 1;
    }
}
// @lc code=end

