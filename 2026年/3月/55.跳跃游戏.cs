/*
 * @lc app=leetcode.cn id=55 lang=csharp
 *
 * [55] 跳跃游戏
 */

// @lc code=start
public class Solution
{
    public bool CanJump(int[] nums)
    {
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach) return false; // 当前索引不可达
            maxReach = Math.Max(maxReach, i + nums[i]); // 更新最远可达位置
        }
        return true;
    }
}
// @lc code=end

