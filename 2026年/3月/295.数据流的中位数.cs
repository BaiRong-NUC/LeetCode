/*
 * @lc app=leetcode.cn id=295 lang=csharp
 *
 * [295] 数据流的中位数
 */

// @lc code=start
public class MedianFinder
{
    /**
        大根堆存较小一半,小根堆存较大一半;
        每次插入后保持尺寸差不超过1且大根堆不少于小根堆;
        计数不等时取大根堆堆顶，计数相等时两堆顶均值。
    */
    private readonly PriorityQueue<int, int> _maxHeap; // 大根堆，存较小的一半
    private readonly PriorityQueue<int, int> _minHeap; // 小根堆，存较大的一半

    public MedianFinder()
    {
        _maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        _minHeap = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        if (_maxHeap.Count == 0 || num <= _maxHeap.Peek())
        {
            _maxHeap.Enqueue(num, num);
        }
        else
        {
            _minHeap.Enqueue(num, num);
        }

        // 维持两个堆的尺寸差不超过 1，且大根堆数量不少于小根堆
        if (_maxHeap.Count > _minHeap.Count + 1)
        {
            int move = _maxHeap.Dequeue();
            _minHeap.Enqueue(move, move);
        }
        else if (_minHeap.Count > _maxHeap.Count)
        {
            int move = _minHeap.Dequeue();
            _maxHeap.Enqueue(move, move);
        }
    }

    public double FindMedian()
    {
        if (_maxHeap.Count > _minHeap.Count)
        {
            return _maxHeap.Peek();
        }

        // 两边数量相等，取平均
        return (_maxHeap.Peek() + _minHeap.Peek()) / 2.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end

