public class Solution
{
    public int StoreWater(int[] bucket, int[] vat)
    {
        int maxK = vat.Max();
        if (maxK == 0)
        {
            return 0;
        }
        int result = int.MaxValue;
        for (int k = 1; k <= maxK && k < result; k++)
        {
            // k 是最终需要倒水的次数
            int sum = 0; // 总的操作次数
            for (int i = 0; i < bucket.Length; i++)
            {
                // (vat[i] + k - 1) / k 向上取整表示每个桶至少需要的容量
                sum += Math.Max(0, (vat[i] + k - 1) / k - bucket[i]);
            }
            result = Math.Min(result, sum + k);
        }
        return result;
    }
}