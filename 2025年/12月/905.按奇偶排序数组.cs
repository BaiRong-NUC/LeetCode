/*
 * @lc app=leetcode.cn id=905 lang=csharp
 *
 * [905] 按奇偶排序数组
 */

// @lc code=start
public class Solution
{
    public int[] SortArrayByParity(int[] nums)
    {
        int left = 0;// 指向下一个偶数应该放置的位置
        while (left < nums.Length && nums[left] % 2 == 0)
        {
            left += 1;
        }
        int right = nums.Length - 1;
        while (left <= right)
        {
            if (nums[right] % 2 == 0)
            {
                // 交换
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left += 1;
            }
            else
            {
                right -= 1;
            }
        }
        return nums;
    }
}
// @lc code=end

