namespace CSharpDebug
{
    // 使用信号量实现的环形缓冲区生产者-消费者模型
    public class RingBufferProducerConsumer<T>
    {
        private readonly T[] buffer;              // 环形缓冲区数组,临界资源
        private readonly int capacity;            // 缓冲区容量
        private int writeIndex;                   // 写入位置(生产者使用),临界资源
        private int readIndex;                    // 读取位置(消费者使用),临界资源
        private readonly SemaphoreSlim writeSemaphore; // 写位置信号量(初始化为环形缓冲区大小)
        private readonly SemaphoreSlim readSemaphore;  // 数据量信号量(初始化为0)
        private readonly object writeLock = new object();
        private readonly object readLock = new object();

        public RingBufferProducerConsumer(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("容量必须大于0", nameof(capacity));

            this.capacity = capacity;
            this.buffer = new T[capacity];
            this.writeIndex = 0;
            this.readIndex = 0;
            this.writeSemaphore = new SemaphoreSlim(capacity, capacity);
            this.readSemaphore = new SemaphoreSlim(0, capacity);
        }

        // 生产者: 向缓冲区添加数据
        public void Produce(T item)
        {
            try
            {
                this.writeSemaphore.Wait(); // P 减少可写信号量
                int index;
                lock (this.writeLock)
                {
                    index = this.writeIndex;
                    this.writeIndex = (this.writeIndex + 1) % this.capacity;
                    Console.WriteLine($"Producer: {Thread.CurrentThread.ManagedThreadId} at index {index} produced {item}");
                }
                this.buffer[index] = item;
            }
            finally
            {
                this.readSemaphore.Release(); // V 增加可读信号量
            }
        }

        // 消费者: 从缓冲区获取数据
        public T Consume()
        {
            try
            {
                this.readSemaphore.Wait(); // P 减少可读信号量
                int index;
                T item;
                lock (this.readLock)
                {
                    index = this.readIndex;
                    this.readIndex = (this.readIndex + 1) % this.capacity;
                    item = this.buffer[index];
                    Console.WriteLine($"Consumer: {Thread.CurrentThread.ManagedThreadId} at index {index} consumed {item}");
                }
                return item;
            }
            finally
            {
                this.writeSemaphore.Release(); // V 增加可写信号量
            }
        }

        // 释放资源
        public void Dispose()
        {
            this.writeSemaphore.Dispose();
            this.readSemaphore.Dispose();
        }
    }

    public class RingBufferDemo
    {
        public static void RunDemo()
        {
            var ringBuffer = new RingBufferProducerConsumer<int>(5);

            // 3个生产者线程,每个生产10个数据
            Thread[] producers = new Thread[3];
            for (int i = 0; i < producers.Length; i++)
            {
                producers[i] = new Thread(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        ringBuffer.Produce(j);
                        Thread.Sleep(100); // 模拟生产时间
                    }
                });
                producers[i].Start();
            }

            // 2个消费者线程 每个消费者消费15个数据
            Thread[] consumers = new Thread[2];
            for (int i = 0; i < consumers.Length; i++)
            {
                consumers[i] = new Thread(() =>
                {
                    for (int j = 0; j < 15; j++)
                    {
                        ringBuffer.Consume();
                        Thread.Sleep(50); // 模拟消费时间
                    }
                });
                consumers[i].Start();
            }

            // 等待所有线程完成
            foreach (var producer in producers)
            {
                producer.Join();
            }
            foreach (var consumer in consumers)
            {
                consumer.Join();
            }
            ringBuffer.Dispose();
        }
    }
}
