/*
 * @lc app=leetcode.cn id=232 lang=csharp
 *
 * [232] 用栈实现队列
 */

// @lc code=start
public class MyQueue
{
    private Stack<int> stackIn;
    private Stack<int> stackOut;

    public MyQueue()
    {
        stackIn = new Stack<int>();
        stackOut = new Stack<int>();
    }

    public void Push(int x)
    {
        stackIn.Push(x);
    }

    public int Pop()
    {
        if (stackOut.Count == 0)
        {
            while (stackIn.Count > 0)
            {
                stackOut.Push(stackIn.Pop());
            }
        }
        return stackOut.Pop();
    }

    public int Peek()
    {
        if (stackOut.Count == 0)
        {
            while (stackIn.Count > 0)
            {
                stackOut.Push(stackIn.Pop());
            }
        }
        return stackOut.Peek();
    }

    public bool Empty()
    {
        return stackIn.Count == 0 && stackOut.Count == 0;
    }

}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
// @lc code=end

