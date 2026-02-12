/*
 * @lc app=leetcode.cn id=34 lang=csharp
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 */

// @lc code=start
public class Solution
{
    private int FindPosition(int[] nums, int target, bool findFirst)
    {
        int left = 0, right = nums.Length - 1;
        int position = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                position = mid;
                if (findFirst)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return position;
    }
    public int[] SearchRange(int[] nums, int target)
    {
        int first = FindPosition(nums, target, true);
        int last = FindPosition(nums, target, false);
        return [first, last];
    }
}
// @lc code=end

