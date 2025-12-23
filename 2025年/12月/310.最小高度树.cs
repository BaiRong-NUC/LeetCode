/*
 * @lc app=leetcode.cn id=310 lang=csharp
 *
 * [310] 最小高度树
 */

// @lc code=start
public class Solution
{
    public int CountTreeHeight(int[,] graph, int root, int size)
    {
        var visited = new bool[size];
        var queue = new Queue<int>();
        queue.Enqueue(root);
        visited[root] = true;
        int height = -1;
        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                int node = queue.Dequeue();
                // 将临近节点加入队列
                for (int neighbor = 0; neighbor < size; neighbor++)
                {
                    if (graph[node, neighbor] == 1 && !visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            height++;
        }
        return height;
    }
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n == 1) return new List<int> { 0 };

        // 邻接矩阵
        int[,] graph = new int[n, n];
        for (int i = 0; i < edges.Length; i++)
        {
            int a = edges[i][0];
            int b = edges[i][1];
            graph[a, b] = 1;
            graph[b, a] = 1;
        }

        // 最小树的高度
        int minHeight = int.MaxValue;
        var result = new List<int>();

        // 遍历每个节点，计算以该节点为根节点的树的高度(BFS)
        for (int root = 0; root < n; root++)
        {
            int height = CountTreeHeight(graph, root, n);
            if (height < minHeight)
            {
                minHeight = height;
                result.Clear();
                result.Add(root);
            }
            else if (height == minHeight)
            {
                result.Add(root);
            }
        }
        return result;
    }
}
// @lc code=end

