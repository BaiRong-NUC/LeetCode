/*
 * @lc app=leetcode.cn id=26 lang=csharp
 *
 * [26] 删除有序数组中的重复项
 */

// @lc code=start
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;
        int left = 0;
        int right = 1;
        while (right < nums.Length)
        {
            if (nums[left] != nums[right])
            {
                left++;
                nums[left] = nums[right];
            }
            right++;
        }
        return left + 1;
    }
}
// @lc code=end

