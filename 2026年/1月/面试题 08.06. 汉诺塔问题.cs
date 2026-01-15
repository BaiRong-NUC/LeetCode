public class Solution
{
    // 将 A 杆上的 n 个盘子移动到 C 杆上，借助 B 杆，A 杆子上从小到大排列，放到 C 杆上也要从小到大排列
    public void Hanota(IList<int> A, IList<int> B, IList<int> C)
    {
        Move(A.Count, A, B, C);
    }

    private void Move(int n, IList<int> A, IList<int> B, IList<int> C)
    {
        if (n == 0)
        {
            return;
        }

        // 将 A 上的 n-1 个盘子经 C 移到 B
        Move(n - 1, A, C, B);

        // 将 A 上的第 n 个盘子移到 C
        C.Add(A[A.Count - 1]);
        A.RemoveAt(A.Count - 1);

        // 将 B 上的 n-1 个盘子经 A 移到 C
        Move(n - 1, B, A, C);
    }
}