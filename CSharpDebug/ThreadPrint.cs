namespace ThreadPrint
{
    public class PrintCur
    {
        //条件变量
        private readonly object locker = new object();
        private int state = 0; // 0表示线程A打印,1表示线程B打印 (条件变量)
        private int count = 1; // 临界资源

        public void Print()
        {
            Thread threadA = new Thread(() =>
            {
                while (true)
                {
                    lock (this.locker)
                    {
                        while (this.state != 0) Monitor.Wait(this.locker); // 等待状态切换
                        if (this.count > 100)
                        {
                            this.state = 1;
                            Monitor.PulseAll(this.locker);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Thread A: {this.count++}");
                            this.state = 1;
                            Monitor.Pulse(this.locker);
                        }
                    }
                }
            });

            Thread threadB = new Thread(() =>
            {
                while (true)
                {
                    lock (this.locker)
                    {
                        while (this.state != 1) Monitor.Wait(this.locker);
                        if (this.count > 100)
                        {
                            this.state = 0;
                            Monitor.PulseAll(this.locker);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Thread B: {this.count++}");
                            this.state = 0;
                            Monitor.Pulse(this.locker);
                        }
                    }
                }
            });

            threadA.Start();
            threadB.Start();
            threadA.Join();
            threadB.Join();
        }
    }
}