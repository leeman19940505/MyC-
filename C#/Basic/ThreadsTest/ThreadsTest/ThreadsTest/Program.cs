using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsTest
{
    //相对线程优先级：Idle Lowest BelowNormal Normal AboveNormal Highest Time-Critival
    //Priority属性（ThreadPriority）Lowest BelowNormal Normal AboveNormal Highest; CLR保留 Idle Time-Critical 
    class Program
    {
        //前台线程和后台线程：当所有前台线程停止运行后，CLR会强制结束所有仍在运行的后台线程
        static void Main(string[] args) //前台线程
        {
            //threadTest1(); //后台线程
            //threadTest2(); //前台线程
            //threadpoolTest(); //线程池
            //threadpoolRemoveTest(); //协作式取消线程池线程
            //threadSynchronizeTest1(); //线程同步 在多线程程序中 后者线程只有等待前者线程完成后才能继续执行 Monitor
            threadSynchronizeTest2();
        }

        public static void threadTest1()
        {
            Thread backThread = new Thread(Worker);
            backThread.IsBackground = true; //指定为后台线程
            backThread.Start(); //执行Work函数代码
            //使主线程在后台线程执行完后再执行，即主线程也进入睡眠且睡眠时间比后台线程更长
            //Thread.Sleep(2000); 
            //
            backThread.Join();
            Console.WriteLine("从主线程中退出");
        }

        //Main执行完毕后CLR会终止Worker Worker线程不会执行
        public static void Worker() //后台线程
        {
            Thread.Sleep(1000); //后台线程睡眠1秒 然后再执行
            Console.WriteLine("从后台线程退出");
        }

        public static void threadTest2()
        {
            Thread paramThread = new Thread(new ParameterizedThreadStart(Worker1)); //前台线程
            paramThread.Name = "线程1";
            paramThread.Start("123");
            Console.WriteLine("从主线程返回");
        }

        public static void Worker1(object data)
        {
            Thread.Sleep(1000);
            Console.WriteLine("传入参数为：" + data.ToString());
            Console.Write("从线程1返回");
            Console.Read();
        }

        public static void threadpoolTest()
        {
            //线程池 避免因通过Thread手动创建线程而造成的损失
            //创建的线程为后台线程 优先级默认为normal
            Console.WriteLine("主线程ID = {0}", Thread.CurrentThread.ManagedThreadId);
            //public delegate void WaitCallback(Object state)
            ThreadPool.QueueUserWorkItem(CallBackWorkItem);
            ThreadPool.QueueUserWorkItem(CallBackWorkItem, "work");
            Thread.Sleep(3000);
            Console.WriteLine("主线程退出");
        }

        private static void CallBackWorkItem(object state)
        {
            Console.WriteLine("线程池线程开始执行");
            if(state != null)
            {
                Console.WriteLine("线程池线程ID = {0} 传入的参数为 {1}", Thread.CurrentThread.ManagedThreadId, state.ToString());
            }
            else
            {
                Console.WriteLine("线程池线程ID = {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }

        private static void threadpoolRemoveTest()
        {
            Console.WriteLine("主线程运行");
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(callback, cts.Token);
            Console.WriteLine("按下回车键来取消操作");
            Console.Read();
            cts.Cancel(); // 取消请求
            Console.ReadKey();
        }

        private static void callback(object state)
        {
            CancellationToken token = (CancellationToken)state;
            Console.WriteLine("开始计数");
            Count(token, 1000);
        }

        private static void Count(CancellationToken token, int countto)
        {
            for(int i = 0; i < countto; i++)
            {
                if(token.IsCancellationRequested) //按回车时返回true
                {
                    Console.WriteLine("计数取消");
                    return;
                }

                Console.WriteLine("计数为：" + i);
                Thread.Sleep(300);
            }

            Console.WriteLine("计数完成");
        }

        static int tickets = 100;
        static object globalObj = new object(); //辅助对象
        private static void threadSynchronizeTest1()
        {
            Thread thread1 = new Thread(SaleTicketThread1);
            Thread thread2 = new Thread(SaleTicketThread2);
            thread1.Start();
            thread2.Start();
            //Thread.Sleep(4000);
        }

        private static void SaleTicketThread1()
        {
            //while(true)
            //{
            //    if(tickets > 0)
            //    {
            //        Console.WriteLine("线程1出票：" + tickets--);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            while(true)
            {
                try
                {
                    Monitor.Enter(globalObj); //在object对象上获取排他锁
                    Thread.Sleep(1);
                    if(tickets > 0)
                    {
                        Console.WriteLine("线程1出票：" + tickets--);
                    }
                    else
                    {
                        break;
                    }
                }
                finally
                {
                    Monitor.Exit(globalObj); //释放指定对象上的排他锁
                }
            }
        }

        private static void SaleTicketThread2()
        {
            //while (true)
            //{
            //    if (tickets > 0)
            //    {
            //        Console.WriteLine("线程2出票：" + tickets--);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            while (true)
            {
                try
                {
                    Monitor.Enter(globalObj); //在object对象上获取排他锁
                    Thread.Sleep(1);
                    if (tickets > 0)
                    {
                        Console.WriteLine("线程2出票：" + tickets--);
                    }
                    else
                    {
                        break;
                    }
                }
                finally
                {
                    Monitor.Exit(globalObj); //释放指定对象上的排他锁
                }
            }
        }

        private static void threadSynchronizeTest2()
        {
            int x = 0;
            const int iterationNumber = 5000000;
            Stopwatch sw = Stopwatch.StartNew();
            for(int i = 0; i < iterationNumber; i++)
            {
                x++;
            }

            Console.WriteLine("不使用锁的情况下花费的时间：{0} ms", sw.ElapsedMilliseconds);
            sw.Restart();

            for(int i = 0; i < iterationNumber; i++)
            {
                Interlocked.Increment(ref x);
            }

            Console.WriteLine("使用锁的情况下花费的时间：{0} ms", sw.ElapsedMilliseconds);
            Console.Read(); 
        }

    }
}
