/*
 * @lc app=leetcode.cn id=207 lang=csharp
 *
 * [207] 课程表
 */

// @lc code=start
public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // 1. 构造有向图来表示课程的依赖关系
        //  0 -> 1 表示要学习课程 1 需要先学习课程 0

        // 有向图的邻接表：graph[i] 表示课程 i 的后续课程列表
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            graph[i] = new List<int>();
        }
        // 入度数组：inDegree[i] 表示课程 i 的前置课程数量
        int[] inDegree = new int[numCourses];
        // 构建图和入度数组
        foreach (var prerequisite in prerequisites)
        {
            int from = prerequisite[1];
            int to = prerequisite[0];
            graph[from].Add(to);
            inDegree[to]++;
        }

        // 2. 使用拓扑排序判断是否存在环,存在环则无法完成所有课程
        Queue<int> queue = new Queue<int>();
        // 将所有入度为 0 的课程加入队列
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        int finishedCourses = 0; // 记录已完成的课程数量
        while (queue.Count > 0)
        {
            int course = queue.Dequeue(); // 学习这门课程
            finishedCourses++;
            // 依赖这门课程的后续课程入度减 1 
            foreach (var nextCourse in graph[course])
            {
                inDegree[nextCourse]--;
                // 如果入度变为 0，加入队列
                if (inDegree[nextCourse] == 0)
                {
                    queue.Enqueue(nextCourse);
                }
            }
        }
        return finishedCourses == numCourses;
    }
}
// @lc code=end

