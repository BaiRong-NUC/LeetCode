/*
 * @lc app=leetcode.cn id=525 lang=csharp
 *
 * [525] 连续数组
 */

// @lc code=start
public class Solution
{
    public int FindMaxLength(int[] nums)
    {
        int maxLength = 0;
        // countIndexMap[i] = j 表示和i时，第一次出现的索引为j
        Dictionary<int, int> countIndexMap = new Dictionary<int, int>();

        // 初始化，计数为0时的索引为-1
        countIndexMap[0] = -1;

        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // 将0视为-1，1视为1
            count += (nums[i] == 0 ? -1 : 1);

            // 如果之前出现过相同的和，更新最大长度
            if (countIndexMap.ContainsKey(count))
            {
                maxLength = Math.Max(maxLength, i - countIndexMap[count]);
            }
            else
            {
                // 记录第一次出现的索引
                countIndexMap[count] = i;
            }
        }
        return maxLength;
    }
}
// @lc code=end

