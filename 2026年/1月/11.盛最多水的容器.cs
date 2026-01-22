/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
public class Solution
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int ret = 0;
        while (left < right)
        {
            ret = Math.Max(ret, Math.Min(height[left], height[right]) * (right - left));
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return ret;
    }
}
// @lc code=end

