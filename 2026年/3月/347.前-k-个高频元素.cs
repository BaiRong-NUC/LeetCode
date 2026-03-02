/*
 * @lc app=leetcode.cn id=347 lang=csharp
 *
 * [347] 前 K 个高频元素
 */

// @lc code=start
public class Heap<T>
{
    private readonly List<T> data = new List<T>();
    private readonly IComparer<T> comparison;

    public Heap(IComparer<T>? comparer = null)
    {
        this.comparison = comparer ?? Comparer<T>.Default;
    }
    public int Count => data.Count;
    public bool IsEmpty => data.Count == 0;

    public void Push(T item)
    {
        data.Add(item);
        SiftUp(data.Count - 1);
    }

    public T Pop()
    {
        if (this.IsEmpty) throw new InvalidOperationException("Heap is empty.");
        T root = data[0];
        T last = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        if (!this.IsEmpty)
        {
            data[0] = last;
            SiftDown(0);
        }
        return root;
    }

    public T Peek()
    {
        if (this.IsEmpty) throw new InvalidOperationException("Heap is empty.");
        return data[0];
    }

    // 从数组index位置向上调整
    private void SiftUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            // 当前节点大于父节点，调整结束(默认为小堆)
            if (this.comparison.Compare(this.data[index], this.data[parent]) >= 0) break;
            (data[index], data[parent]) = (data[parent], data[index]);
            index = parent;
        }
    }
    // 从数组index位置向下调整
    private void SiftDown(int index)
    {
        while (true)
        {
            int left = index * 2 + 1, right = index * 2 + 2;
            int smallest = index;
            // 左右子节点中较小的一个
            if (left < data.Count && this.comparison.Compare(this.data[left], this.data[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < data.Count && this.comparison.Compare(this.data[right], this.data[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest == index) break; // 当前节点已经是最小的，调整结束
            (data[index], data[smallest]) = (data[smallest], data[index]);
            index = smallest;
        }
    }
}
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!frequencyMap.ContainsKey(num))
            {
                frequencyMap[num] = 0;
            }
            frequencyMap[num]++;
        }
        var heap = new Heap<(int num, int freq)>(Comparer<(int num, int freq)>.Create((a, b) => a.freq.CompareTo(b.freq))); // 小堆
        foreach (var kvp in frequencyMap)
        {
            heap.Push((kvp.Key, kvp.Value));
            if (heap.Count > k)
            {
                heap.Pop();
            }
        }
        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = heap.Pop().num;
        }
        return result;
    }
}
// @lc code=end

