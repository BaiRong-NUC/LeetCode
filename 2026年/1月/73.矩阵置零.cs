/*
 * @lc app=leetcode.cn id=73 lang=csharp
 *
 * [73] 矩阵置零
 */

// @lc code=start
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        HashSet<(int, int)> zeroPositions = new HashSet<(int, int)>();
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    // 本行,本列记录0位置
                    for (int r = 0; r < rows; r++)
                    {
                        zeroPositions.Add((r, j));
                    }
                    for (int c = 0; c < cols; c++)
                    {
                        zeroPositions.Add((i, c));
                    }
                }
            }
        }
        foreach (var (r, c) in zeroPositions)
        {
            matrix[r][c] = 0;
        }
    }
}
// @lc code=end

