/*
 * @lc app=leetcode.cn id=1658 lang=csharp
 *
 * [1658] 将 x 减到 0 的最小操作数
 */

// @lc code=start
public class Solution
{
    public int MinOperations(int[] nums, int x)
    {
        // 中间一块是连续的，看作一个滑动窗口，滑一遍求窗口最大长度即可
        int len = -1;
        int sum = nums.Sum();
        int left = 0, right = 0;
        int target = sum - x;
        int windowSum = 0;
        if (target < 0) return -1;
        while (right < nums.Length)
        {
            windowSum += nums[right];
            right += 1;
            while (windowSum > target)
            {
                windowSum -= nums[left];
                left += 1;
            }
            if (windowSum == target)
            {
                len = Math.Max(len, right - left);
            }
        }
        return len == -1 ? -1 : nums.Length - len;
    }
}
// @lc code=end

