/*
 * @lc app=leetcode.cn id=429 lang=csharp
 *
 * [429] N 叉树的层序遍历
 */

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var currentLevel = new List<int>();
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                if (node == null) continue;
                currentLevel.Add(node.val);
                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }
            result.Add(currentLevel);
        }
        return result;
    }
}
// @lc code=end

