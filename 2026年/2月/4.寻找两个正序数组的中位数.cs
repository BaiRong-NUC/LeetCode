/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int nums1Len = nums1.Length, nums2Len = nums2.Length;
        if (nums1Len > nums2Len)
        {
            // 保证 nums1 是较短的数组
            return FindMedianSortedArrays(nums2, nums1);
        }
        int totalLen = nums1Len + nums2Len;
        // 若totalLen为奇数,第一组和第二组大小相同(nums1Len + nums2Len) / 2
        // 若totalLen为偶数,第一组比第二组多一个元素(nums1Len + nums2Len + 1) / 2
        // 合并为(nums1Len + nums2Len + 1) / 2 向下取整
        int halfLen = (totalLen + 1) / 2;
        // 最右插入∞ 哨兵位
        nums1 = nums1.Append(int.MaxValue).ToArray();
        nums2 = nums2.Append(int.MaxValue).ToArray();
        // 最左插入-∞
        nums1 = nums1.Prepend(int.MinValue).ToArray();
        nums2 = nums2.Prepend(int.MinValue).ToArray();
        // 枚举
        // nums1有leftMax个元素在第一组
        // nums2有halfLen - leftMax个元素在第一组
        int leftMax = 0, rightMin = halfLen;
        while (true)
        {
            if (nums1[leftMax] <= nums2[rightMin + 1] &&
                nums1[leftMax + 1] >= nums2[rightMin])
            {
                int maxLeft = Math.Max(nums1[leftMax], nums2[rightMin]); // 第一组的最大值
                int minRight = Math.Min(nums1[leftMax + 1], nums2[rightMin + 1]); // 第二组的最小值
                return (nums1Len + nums2Len) % 2 == 0 ? (maxLeft + minRight) / 2.0 : maxLeft;
            }
            leftMax++;
            rightMin--;
        }
        throw new InvalidOperationException("Error");
    }
}
// @lc code=end

