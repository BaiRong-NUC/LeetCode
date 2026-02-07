/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution
{
    public int[][] directions =
    [
        [-1, 0], // 上
        [1, 0],  // 下   
        [0, -1], // 左
        [0, 1]   // 右
    ];
    public int NumIslands(char[][] grid)
    {
        // BFS 广度优先
        int rows = grid.Length;
        int cols = grid[0].Length;
        int islandCount = 0;
        // 标记访问过的陆地
        bool[,] visited = new bool[rows, cols];
        Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row][col] == '1' && !visited[row, col])
                {
                    // 发现一个新的岛屿
                    islandCount++;
                    visited[row, col] = true;
                    queue.Enqueue((row, col));
                    // 周围的陆地全部标记为已访问
                    while (queue.Count > 0)
                    {
                        var (currRow, currCol) = queue.Dequeue();
                        foreach (var direction in directions)
                        {
                            int newRow = currRow + direction[0];
                            int newCol = currCol + direction[1];
                            if (newRow >= 0 && newRow < rows &&
                                newCol >= 0 && newCol < cols &&
                                grid[newRow][newCol] == '1' &&
                                !visited[newRow, newCol])
                            {
                                visited[newRow, newCol] = true;
                                queue.Enqueue((newRow, newCol));
                            }
                        }
                    }
                }
            }
        }
        return islandCount;
    }
}
// @lc code=end

