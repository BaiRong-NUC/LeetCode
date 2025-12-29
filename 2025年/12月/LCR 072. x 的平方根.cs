public class Solution
{
    public int MySqrt(int x)
    {
        // if (x == 1) return 1;
        // int ret = 0;
        // for (int i = 1; i <= x / 2; i++)
        // {
        //     if ((long)i * i <= x)
        //     {
        //         ret = i;
        //     }
        //     else
        //     {
        //         break;
        //     }
        // }
        // return ret;

        // 双指针
        if (x == 0) return 0;
        int left = 1;
        int right = x;
        int ret = -1;
        while (left <= right)
        {
            int mid = left + (right - left + 1) / 2;
            if ((long)mid * mid <= x) //因为要向下取整
            {
                ret = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return ret;
    }
}