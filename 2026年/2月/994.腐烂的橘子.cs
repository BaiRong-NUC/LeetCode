/*
 * @lc app=leetcode.cn id=994 lang=csharp
 *
 * [994] 腐烂的橘子
 */

// @lc code=start
public class Solution
{
    int[][] directions =
    [
        [-1, 0], // 上
        [1, 0],  // 下   
        [0, -1], // 左
        [0, 1]   // 右
    ];
    public int OrangesRotting(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
        int minutes = 0;
        int freshCount = 0;
        // 初始化队列，加入所有腐烂的橘子位置，并统计新鲜橘子数量
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row][col] == 2)
                {
                    queue.Enqueue((row, col));
                }
                else if (grid[row][col] == 1)
                {
                    freshCount++;
                }
            }
        }
        // BFS 传播腐烂
        int[,] visited = new int[rows, cols];
        while (queue.Count > 0 && freshCount > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                (int currRow, int currCol) = queue.Dequeue();
                foreach (var direction in directions)
                {
                    int newRow = currRow + direction[0];
                    int newCol = currCol + direction[1];
                    if (newRow >= 0 && newRow < rows &&
                        newCol >= 0 && newCol < cols &&
                        grid[newRow][newCol] == 1 &&
                        visited[newRow, newCol] == 0)
                    {
                        // 新鲜橘子变为腐烂
                        grid[newRow][newCol] = 2;
                        visited[newRow, newCol] = 1;
                        freshCount--;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
            // 每完成一轮传播，分钟数加一
            minutes++;
        }
        return freshCount == 0 ? minutes : -1;
    }
}
// @lc code=end

