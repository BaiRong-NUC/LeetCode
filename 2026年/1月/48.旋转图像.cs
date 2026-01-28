/*
 * @lc app=leetcode.cn id=48 lang=csharp
 *
 * [48] 旋转图像
 */

// @lc code=start
public class Solution
{
    public void Rotate(int[][] matrix)
    {
        // 转置矩阵
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = i + 1; j < matrix[0].Length; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
        // 左右列交换
        int left = 0;
        int right = matrix[0].Length - 1;
        while (left < right)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int temp = matrix[row][left];
                matrix[row][left] = matrix[row][right];
                matrix[row][right] = temp;
            }
            left++;
            right--;
        }
    }
}
// @lc code=end

