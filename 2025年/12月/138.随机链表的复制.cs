/*
 * @lc app=leetcode.cn id=138 lang=csharp
 *
 * [138] 随机链表的复制
 */
public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}
// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution
{
    Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    public Node CopyRandomList(Node head)
    {
        if (head == null)
        {
            return null;
        }
        if (!visited.ContainsKey(head))
        {
            Node node = new Node(head.val);
            visited[head] = node;
            node.next = CopyRandomList(head.next);
            node.random = CopyRandomList(head.random);
        }
        return visited[head];
    }
}
// @lc code=end

