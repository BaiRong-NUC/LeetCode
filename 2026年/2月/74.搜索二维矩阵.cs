/*
 * @lc app=leetcode.cn id=74 lang=csharp
 *
 * [74] 搜索二维矩阵
 */

// @lc code=start
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return false;
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int left = 0, right = rows * cols - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int midValue = matrix[mid / cols][mid % cols];

            if (midValue == target)
            {
                return true;
            }
            else if (midValue < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
}
// @lc code=end

