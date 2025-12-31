namespace CSharpDebug
{
    using SingletonPattern;
    public class Solution
    {
        public int[] SortArrayByParity(int[] nums)
        {
            int left = 0;// 指向下一个偶数应该放置的位置
            while (nums[left] % 2 == 0)
            {
                left += 1;
            }
            int right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[right] % 2 == 0)
                {
                    // 交换
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                    left += 1;
                }
                else
                {
                    right -= 1;
                }
            }
            return nums;
        }
    }
    public class CSharpDebug
    {
        static void Main(string[] args)
        {
            Sort.Solution solution = new Sort.Solution();
            int[] nums = new int[] { 4, 3, 1, 2, 4 };
            // var result = solution.QuickSort(nums);
            var result = solution.MergeSort(nums);
            foreach (var num in result)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // 测试单例模式
            HungrySingleton hungrySingleton = HungrySingleton.instance;
            hungrySingleton.ShowMessage();
            Console.WriteLine(Object.ReferenceEquals(hungrySingleton, HungrySingleton.instance));
            LazySingleton lazySingleton = LazySingleton.instance;
            lazySingleton.ShowMessage();
            Console.WriteLine(Object.ReferenceEquals(lazySingleton, LazySingleton.instance));

            // 测试线程交替打印
            ThreadPrint.PrintCur printCur = new ThreadPrint.PrintCur();
            printCur.Print();

            // 生产者消费者环形缓冲区
            Console.WriteLine("==========");
            RingBufferDemo.RunDemo();
        }
    }
}