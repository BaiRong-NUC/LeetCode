namespace SingletonPattern
{
    // 饿汉模式单例,在程序开始时初始化对象
    public class HungrySingleton
    {
        private static HungrySingleton _instance = new HungrySingleton();

        private HungrySingleton() { }

        public static HungrySingleton instance
        {
            get
            {
                return _instance;
            }
        }

        public void ShowMessage()
        {
            Console.WriteLine("Hungry Singleton Pattern 调用成功！");
        }
    }

    // 懒汉模式单例,在第一次使用时初始化对象,延迟加载
    public class LazySingleton
    {
        private static LazySingleton? _instance;
        private static readonly object _lock = new object();

        private LazySingleton() { }

        public static LazySingleton instance
        {
            get
            {
                if (_instance == null) // 避免每次访问都进入锁，减少性能开销
                {
                    lock (_lock)
                    {
                        if (_instance == null) // 防止多个线程在第一个判断同时为 null 时并发创建多个实例
                        {
                            _instance = new LazySingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        public void ShowMessage()
        {
            Console.WriteLine("Lazy Singleton Pattern 调用成功！");
        }
    }
}