/*
 * @lc app=leetcode.cn id=208 lang=csharp
 *
 * [208] 实现 Trie (前缀树)
 */

// @lc code=start
public class TireNode
{
    public TireNode[] children;
    public bool isEnd;

    public TireNode()
    {
        // 字典树的每个节点最多有 26 个子节点，分别对应 'a' 到 'z'
        children = new TireNode[26];
        isEnd = false;
    }
}

public class Trie
{
    // 26叉树
    private TireNode root;
    public Trie()
    {
        root = new TireNode();
    }

    public void Insert(string word)
    {
        TireNode current = root;
        foreach (char ch in word)
        {
            int index = ch - 'a';
            // 检测这颗树上是否存在该字符对应的子节点
            if (current.children[index] == null)
            {
                // 不存在则创建新的子节点
                current.children[index] = new TireNode();
            }
            // 字典树共享前缀节点
            current = current.children[index];
        }
        // 标记单词结束
        current.isEnd = true;
    }

    public bool Search(string word)
    {
        TireNode current = root;
        foreach (char ch in word)
        {
            int index = ch - 'a';
            // 检测这颗树上是否存在该字符对应的子节点
            if (current.children[index] == null)
            {
                // 不存在则说明单词不存在
                return false;
            }
            current = current.children[index];
        }
        // 检测单词结束标记,避免出现前缀是单词的情况
        return current.isEnd;
    }

    public bool StartsWith(string prefix)
    {
        TireNode current = root;
        foreach (char ch in prefix)
        {
            int index = ch - 'a';
            // 检测这颗树上是否存在该字符对应的子节点
            if (current.children[index] == null)
            {
                // 不存在则说明前缀不存在
                return false;
            }
            current = current.children[index];
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

