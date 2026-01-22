/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        if (nums == null || nums.Length < 3) return result;

        // 排序，便于去重和双指针
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // 最小值>0，后面不可能有和为0的组合
            if (nums[i] > 0) break;

            // 跳过重复的第一个数
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // 跳过重复的left和right
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;  // 和太小，左指针右移
                }
                else
                {
                    right--; // 和太大，右指针左移
                }
            }
        }

        return result;
    }
}
// @lc code=end

