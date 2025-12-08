/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int tail = m + n - 1;
        int tailA = m - 1;
        int tailB = n - 1;
        while (tailA >= 0 && tailB >= 0)
        {
            if (nums1[tailA] > nums2[tailB])
            {
                nums1[tail--] = nums1[tailA--];
            }
            else
            {
                nums1[tail--] = nums2[tailB--];
            }
        }
        while (tailB >= 0)
        {
            nums1[tail--] = nums2[tailB--];
        }
        while (tailA >= 0)
        {
            nums1[tail--] = nums1[tailA--];
        }
    }
}
// @lc code=end