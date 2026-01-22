/*
 * @lc app=leetcode.cn id=283 lang=csharp
 *
 * [283] 移动零
 */

// @lc code=start
public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] != 0)
            {
                nums[left] = nums[right];
                left++;
            }
        }
        for (int i = left; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}
// @lc code=end

