/*
 * @lc app=leetcode.cn id=41 lang=csharp
 *
 * [41] 缺失的第一个正数
 */

// @lc code=start
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        // 将负数设置成一个大于数组长度的数,正数小于nums.Length的数字放到对应的位置上,其余正数不管
        Action<int[], int, int> Swap = (arr, a, b) =>
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        };
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0)
            {
                nums[i] = nums.Length + 1;
            }
            // while防止交换后新交换进来的数也需要交换
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
            {
                Swap(nums, i, nums[i] - 1);
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }
        return nums.Length + 1;
    }
}
// @lc code=end

