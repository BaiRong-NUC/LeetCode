/*
 * @lc app=leetcode.cn id=51 lang=csharp
 *
 * [51] N 皇后
 */

// @lc code=start
public class Solution
{
    public bool IsValid(List<string> board, int row, int col)
    {
        int n = board.Count;
        // 检查列
        for (int i = 0; i < n; i++)
        {
            if (board[i][col] == 'Q')
            {
                return false;
            }
        }
        // 检查左上角
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }
        // 检查右上角
        for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }
        // 从上到下放的皇后,下面不需要检查
        return true;
    }
    public void Backtracking(int boardSize, int row, List<string> board, List<IList<string>> result)
    {
        if (row == boardSize)
        {
            result.Add([.. board]);
            return;
        }
        // 选择这一行的每一列
        for (int col = 0; col < board[row].Length; col++)
        {
            // 选择row,col位置放置皇后
            if (this.IsValid(board, row, col))
            {
                char[] rowArray = board[row].ToCharArray();
                rowArray[col] = 'Q';
                board[row] = new string(rowArray);

                this.Backtracking(boardSize, row + 1, board, result);

                rowArray[col] = '.';
                board[row] = new string(rowArray);
            }
        }
    }
    public IList<IList<string>> SolveNQueens(int n)
    {
        List<IList<string>> result = new List<IList<string>>();
        // 棋盘
        List<string> board = new List<string>();
        for (int i = 0; i < n; i++)
        {
            board.Add(new string('.', n));
        }
        this.Backtracking(n, 0, board, result);
        return result;
    }
}
// @lc code=end

