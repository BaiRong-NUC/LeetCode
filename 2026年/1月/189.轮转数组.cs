/*
 * @lc app=leetcode.cn id=189 lang=csharp
 *
 * [189] 轮转数组
 */

// @lc code=start
public class Solution
{
    private void Reverse(int[] nums, int left, int right)
    {
        while (left < right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }
    public void Rotate(int[] nums, int k)
    {
        k = k % nums.Length;
        Reverse(nums, 0, nums.Length - k - 1);
        Reverse(nums, nums.Length - k, nums.Length - 1);
        Reverse(nums, 0, nums.Length - 1);
    }
}
// @lc code=end

