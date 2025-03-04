using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程
{
    class Program
    {
        static int bookCount = 1000;

        static void Main(string[] args)
        {

            //线程（Thread）是进程中的基本执行单元，线程是操作系统分配CPU时间的基本单位
            //一个进程可以包含若干个线程，在进程入口执行的第一个线程被视为这个进程的主线程。

            //多线程的优点：可以同时完成多个任务；可以使程序的响应速度更快；
            //可以让占用大量处理时间的任务或当前没有进行处理的任务定期将处理时间让给别的任务；
            //可以随时停止任务（报错）；可以设置每个任务的优先级以优化程序性能。

            //多线程的缺点：线程也是程序，所以线程需要占用内存，线程越多，占用内存也越多。
            //多线程需要协调和管理，所以需要占用CPU时间以便跟踪线程。
            //线程之间对共享资源的访问会相互影响，必须解决争用共享资源的问题。
            //线程太多会导致控制太复杂，最终可能造成很多程序缺陷。

            //测试：输出当前运行的线程id
            //Console.WriteLine($"主线程的id：{Thread.CurrentThread.ManagedThreadId}");


            //测试：创建一个新的线程，并打印新创建的线程id
            //Thread thread = new Thread(() => 
            //{
            //    Console.WriteLine($"自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //});

            //线程是有状态：运行、结束、阻塞
            //开始运行线程
            //thread.Start();

            //前台线程：只有所有的前台线程都结束，应用程序才能结束。默认情况下创建的线程都是前台线程
            //后台线程：只要所有的前台线程结束，后台线程自动结束。通过Thread.IsBackground设置后台线程。
            //必须在调用Start方法之前设置线程的类型，否则一旦线程运行，将无法改变其类型。

            //测试：如何创建后台线程
            //Thread thread = new Thread(() =>
            //{
            //    Console.WriteLine($"自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //});

            //改成后台线程
            //thread.IsBackground = true;
            //thread.Start();

            //测试：前台线程被关闭，后台线程自动也被关闭。
            #region 测试
            //前台
            //Thread thread1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(500);
            //        Console.WriteLine($"线程1号，打印次数{i+1}，自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //    }

            //});

            //thread1.Start();

            ////后台
            //Thread thread2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine($"线程2号，打印次数{i + 1}，自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //    }
            //});

            ////改成后台线程
            //thread2.IsBackground = true;
            //thread2.Start();


            #endregion

            //线程池：由于线程的创建和销毁需要耗费一定的开销，过多的使用线程会造成内存资源的浪费，
            //出于对性能的考虑，于是引入了线程池的概念。线程池维护一个请求队列，线程池的代码从队列提取任务，
            //然后委派给线程池的一个线程执行，线程执行完不会被立即销毁，这样既可以在后台执行任务，又可以减少线程创建和销毁所带来的开销。
            //线程池线程默认为后台线程（IsBackground）

            //测试：观察使用线程池来创建多个线程打印线程id
            //ThreadPool
            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(s =>
            //    {
            //        Console.WriteLine($"线程池创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //    });
            //}

            #region 线程同步,线程安全
            Thread thread1 = new Thread(() =>
            {
                while (true)
                {
                    if (bookCount > 0)
                    {
                        bookCount -= 1;
                        Console.WriteLine("线程：" + Thread.CurrentThread.ManagedThreadId + "，卖掉了一本书，" + "剩余" + bookCount + "本书");

                    }
                    else
                    {
                        break;
                    }


                }
            });

            Thread thread2 = new Thread(() =>
            {
                while (true)
                {
                    if (bookCount > 0)
                    {
                        bookCount -= 1;
                        Console.WriteLine("线程：" + Thread.CurrentThread.ManagedThreadId + "，卖掉了一本书，" + "剩余" + bookCount + "本书");

                    }
                    else
                    {
                        break;
                    }


                }
            });
            Thread thread3 = new Thread(() =>
            {
                while (true)
                {

                    if (bookCount > 0)
                    {
                        bookCount -= 1;
                        Console.WriteLine("线程：" + Thread.CurrentThread.ManagedThreadId + "，卖掉了一本书，" + "剩余" + bookCount + "本书");

                    }
                    else
                    {
                        break;
                    }
                }
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();



            #endregion


            Console.ReadLine();
        }
    }
}
