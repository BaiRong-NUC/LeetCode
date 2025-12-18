public class Solution
{
    // public int Multiply(int A, int B)
    // {
    //     int result = 0;
    //     for (int i = 0; i < B; i++)
    //     {
    //         result += A;
    //     }
    //     return result;
    // }

    public int Multiply(int A, int B)
    {
        if (A == 0 || B == 0) return 0;
        int result = 0;
        int half = Multiply(A, B >> 1);
        if (B % 2 == 0)
        {
            result = half + half;
        }
        else
        {
            result = half + half + A;
        }
        return result;
    }
}