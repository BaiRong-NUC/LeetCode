/*
 * @lc app=leetcode.cn id=79 lang=csharp
 *
 * [79] 单词搜索
 */

// @lc code=start
public class Solution
{
    public int[][] directions =
    [
        [-1, 0],
        [1, 0],
        [0, -1],
        [0, 1]
    ];
    public bool Backtracking(char[][] board, string word, int[,] visited, int row, int col, int index)
    {
        if (index == word.Length) return true;
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length) return false;
        if (visited[row, col] == 1 || board[row][col] != word[index]) return false;
        visited[row, col] = 1;
        foreach (int[] direction in this.directions)
        {
            if (this.Backtracking(board, word, visited, row + direction[0], col + direction[1], index + 1))
            {
                return true;
            }
        }
        visited[row, col] = 0;
        return false;
    }
    public bool Exist(char[][] board, string word)
    {
        int rows = board.Length, cols = board[0].Length;
        List<(int, int)> beginPos = new List<(int, int)>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[i][j] == word[0])
                {
                    beginPos.Add((i, j));
                }
            }
        }
        int[,] visited = new int[rows, cols];
        return beginPos.Any(pos => this.Backtracking(board, word, visited, pos.Item1, pos.Item2, 0));
    }
}
// @lc code=end

