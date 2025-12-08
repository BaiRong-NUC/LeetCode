using System.Collections.Generic;

/*
 * @lc app=leetcode.cn id=146 lang=csharp
 *
 * [146] LRU 缓存
 */

// @lc code=start
public class LRUListNode
{
    public int Key;
    public int Value;
    public LRUListNode Prev;
    public LRUListNode Next;

    public LRUListNode(int key, int value)
    {
        Key = key;
        Value = value;
    }
}
public class LRUCache
{
    private readonly int capacity;
    private int size; // 当前缓存大小
    private readonly Dictionary<int, LRUListNode> cache;
    private readonly LRUListNode head;
    private readonly LRUListNode tail;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LRUListNode>(capacity);
        size = 0;
        head = new LRUListNode(0, 0);
        tail = new LRUListNode(0, 0);
        head.Next = tail;
        tail.Prev = head;
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
        {
            return -1;
        }
        LRUListNode node = cache[key];
        MoveToHead(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            LRUListNode node = cache[key];
            node.Value = value;
            MoveToHead(node);
        }
        else
        {
            LRUListNode newNode = new LRUListNode(key, value);
            cache[key] = newNode;
            AddToHead(newNode);
            size++;
            if (size > capacity)
            {
                LRUListNode tailPrev = PopTail();
                cache.Remove(tailPrev.Key);
                size--;
            }
        }
    }

    private void AddToHead(LRUListNode node)
    {
        node.Prev = head;
        node.Next = head.Next;
        head.Next.Prev = node;
        head.Next = node;
    }

    private void RemoveNode(LRUListNode node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    private void MoveToHead(LRUListNode node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private LRUListNode PopTail()
    {
        LRUListNode node = tail.Prev;
        RemoveNode(node);
        return node;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

