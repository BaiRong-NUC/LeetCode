/*
 * @lc app=leetcode.cn id=155 lang=csharp
 *
 * [155] 最小栈
 */

// @lc code=start
public class MinStack
{
    public Stack<int> stack;
    public Stack<int> minStack;
    public MinStack()
    {
        this.stack = new Stack<int>();
        this.minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        stack.Push(val);
        if (minStack.Count == 0 || val <= minStack.Peek())
        {
            minStack.Push(val);
        }
    }

    public void Pop()
    {
        int top = stack.Pop();
        if (top == minStack.Peek())
        {
            minStack.Pop();
        }
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
// @lc code=end

