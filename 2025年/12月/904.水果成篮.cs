/*
 * @lc app=leetcode.cn id=904 lang=csharp
 *
 * [904] 水果成篮
 */

// @lc code=start
public class Solution
{
    public int TotalFruit(int[] fruits)
    {
        int left = 0;
        int right = 0;
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        int maxFruits = 0;

        while (right < fruits.Length)
        {
            // 扩展右边界，加入当前水果
            if (!countMap.ContainsKey(fruits[right]))
            {
                countMap[fruits[right]] = 0;
            }
            countMap[fruits[right]]++;

            // 如果篮子中水果种类超过2种，收缩左边界
            while (countMap.Count > 2)
            {
                countMap[fruits[left]]--;
                if (countMap[fruits[left]] == 0)
                {
                    countMap.Remove(fruits[left]);
                }
                left++;
            }

            // 更新最大水果数量
            maxFruits = Math.Max(maxFruits, right - left + 1);
            right++;
        }

        return maxFruits;
    }
}
// @lc code=end

