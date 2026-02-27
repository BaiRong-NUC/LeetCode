/*
 * @lc app=leetcode.cn id=153 lang=csharp
 *
 * [153] 寻找旋转排序数组中的最小值
 */

// @lc code=start
public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
            {
                // 最小值在右侧
                left = mid + 1;
            }
            else
            {
                // 最小值在左侧（包括 mid）
                right = mid;
            }
        }
        return nums[left];
    }
}
// @lc code=end

