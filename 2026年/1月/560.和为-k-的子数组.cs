/*
 * @lc app=leetcode.cn id=560 lang=csharp
 *
 * [560] 和为 K 的子数组
 */

// @lc code=start
public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        // prefixSum[i] 表示 nums[0..i-1] 的和
        // 如果 prefixSum[j] - prefixSum[i] = k，则 nums[i..j-1] 的和为 k
        // prefixSumCount 用于记录每个前缀和出现的次数
        Dictionary<int, int> prefixSumCount = new Dictionary<int, int>();
        prefixSumCount[0] = 1; // 前缀和为 0 的情况有 1 种（空数组）

        int prefixSum = 0;
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];

            // 查找是否存在前缀和为 prefixSum - k 的情况
            // 如果存在，说明从那个位置到当前位置的子数组和为 k
            // 从前缀和为 prefixSum - k 位置之后到 i 下标都是和为 k 的子数组
            if (prefixSumCount.ContainsKey(prefixSum - k))
            {
                count += prefixSumCount[prefixSum - k];
            }

            // 记录当前前缀和
            if (prefixSumCount.ContainsKey(prefixSum))
            {
                prefixSumCount[prefixSum]++;
            }
            else
            {
                prefixSumCount[prefixSum] = 1;
            }
        }

        return count;
    }
}
// @lc code=end

