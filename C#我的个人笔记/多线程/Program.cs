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

        static readonly object myLock = new object();

        static void Main(string[] args)
        {
            #region Thread内容

            //线程（Thread）是进程中的基本执行单元，线程是操作系统分配CPU时间的基本单位(单位时间上CPU只在一个线程上)
            //一个进程可以包含若干个线程，在进程入口执行的第一个线程被视为这个进程的主线程。

            //多线程的优点：可以同时完成多个任务；可以使程序的响应速度更快；
            //让占用大量处理时间的任务或定时完成的任务可以考虑使用多线程；
            #region 例子
            //第一种情况，占用大量的时间
            //Console.ReadLine();
            //Console.WriteLine("abc");

            //第二种情况，处理定期任务
            //int i = 0;
            //while (true)
            //{
            //    Console.WriteLine(i);
            //    i++;
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("abc");
            #endregion

            //可以随时停止任务（报错）；可以设置每个线程的优先级以优化程序性能。

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
            //Console.WriteLine("我是线程下面执行的一段话");





            //前台线程：只有所有的前台线程都结束，应用程序才能结束。默认情况下创建的线程都是前台线程
            #region 例子
            //Thread thread = new Thread(() =>
            //{
            //    Console.WriteLine($"自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(5000);
            //});

            //thread.Start();
            #endregion
            //后台线程：只要所有的前台线程结束，后台线程自动结束。通过Thread.IsBackground设置后台线程。
            //必须在调用Start方法之前设置线程的类型，否则一旦线程运行，将无法改变其类型。
            #region 例子
            //测试：如何创建后台线程
            //Thread thread = new Thread(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine($"自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //});

            //改成后台线程
            //thread.IsBackground = true;
            //thread.Start();
            #endregion

            //测试：前台线程被关闭，后台线程自动也被关闭。
            #region 测试
            ////前台
            //Thread thread1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(500);
            //        Console.WriteLine($"线程1号，打印次数{i + 1}，自己创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
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
            //总结：如果需要使用线程先去线程池里找有没有空闲的线程，如果有就拿出来用。如果没有就创建新的线程，但是用完又会放回线程池。
            //线程池线程默认为后台线程（IsBackground）

            //测试：观察使用线程池来创建多个线程打印线程id
            //ThreadPool
            //for (int i = 0; i < 30; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(s =>
            //    {
            //        Console.WriteLine($"线程池创建的线程id：{Thread.CurrentThread.ManagedThreadId}");
            //    });
            //}

            #region 线程同步,线程安全



            //Thread thread1 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        lock (myLock)
            //        {
            //            if (bookCount > 0)
            //            {
            //                bookCount -= 1;
            //                Console.WriteLine("线程：" + Thread.CurrentThread.ManagedThreadId + "，卖掉了一本书，" + "剩余" + bookCount + "本书");

            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //    }
            //});





            //Thread thread2 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        lock (myLock)
            //        {
            //            if (bookCount > 0)
            //            {
            //                bookCount -= 1;
            //                Console.WriteLine("线程：" + Thread.CurrentThread.ManagedThreadId + "，卖掉了一本书，" + "剩余" + bookCount + "本书");

            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //    }
            //});

            //Thread thread3 = new Thread(() =>
            //{
            //    while (true)
            //    {

            //        if (bookCount > 0)
            //        {
            //            bookCount -= 1;
            //            Console.WriteLine("线程：" + Thread.CurrentThread.ManagedThreadId + "，卖掉了一本书，" + "剩余" + bookCount + "本书");

            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //});

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //如果说要解决这个多线程争抢资源的问题，我们可以使用锁的机制，lock
            //lock ()
            //{

            //}

            //Thread.Sleep(2000);
            //Console.WriteLine("这是主线程准备结束前的一句话");
            #endregion
            #endregion

            #region Task

            //Task
            //Task的优势：
            //ThreadPool相比Thread来说具备了很多优势，但是ThreadPool却又存在一些使用上的不方便。
            //如：ThreadPool不支持线程的取消、完成、失败通知等交互性操作
            //Task在线程池的基础上进行了优化，并提供了更多的API

            //使用Task创建任务
            //1、创建Task对象
            //Console.WriteLine($"主线程的id：{Thread.CurrentThread.ManagedThreadId}");

            //Task task = new Task(() =>
            //{
            //    Console.WriteLine("创建了一个任务");
            //    Console.WriteLine($"Task线程的id：{Thread.CurrentThread.ManagedThreadId}");
            //});
            //Console.WriteLine(task.Status.ToString());

            //task.Start();

            //Console.WriteLine(task.Status.ToString());

            //2、使用静态方法Run
            //var task = Task.Run(() =>
            //{
            //    Console.WriteLine("创建了一个任务");
            //});

            //3、使用工程创建
            //var task = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("创建了一个任务");
            //});

            #region Wait
            //等待Task执行完毕后再执行下面的代码
            //var task = Task.Run(() =>
            //{
            //    //.......................
            //    Thread.Sleep(2000);
            //    Console.WriteLine("创建了一个任务");
            //});

            ////Thread.Sleep(3000);
            //task.Wait();
            //Console.WriteLine("最后的代码");
            #endregion

            #region WaitAll
            //等待多个Task执行完毕后再执行下面的代码
            //var task1 = Task.Run(() =>
            //{
            //    //.......................
            //    Thread.Sleep(3000);
            //    Console.WriteLine("创建了一个任务1");
            //});

            //var task2 = Task.Run(() =>
            //{
            //    //.......................
            //    Thread.Sleep(2000);
            //    Console.WriteLine("创建了一个任务2");
            //});

            //Task.WaitAll(task1, task2);

            //Console.WriteLine("最后的代码");

            #endregion

            #region WaitAny
            //等待其中一个Task执行完毕后再执行下面的代码
            //var task1 = Task.Run(() =>
            //{
            //    //.......................
            //    Thread.Sleep(3000);
            //    Console.WriteLine("创建了一个任务1");
            //});

            //var task2 = Task.Run(() =>
            //{
            //    //.......................
            //    Thread.Sleep(2000);
            //    Console.WriteLine("创建了一个任务2");
            //});

            //Task.WaitAny(task1, task2);
            //Console.WriteLine("执行到最后了");

            #endregion

            #region ContinueWith
            //ContinueWith的使用,组合任务
            //var task1 = Task.Run(() =>
            //{
            //    //.......................
            //    Thread.Sleep(3000);
            //    Console.WriteLine("创建了一个任务1");
            //});

            //task1.ContinueWith((t) => 
            //{
            //    Console.WriteLine("创建了一个任务2");
            //});
            #endregion

            #region 取消任务
            //取消任务 CancellationTokenSource
            //var ct = new CancellationTokenSource();
            //Task.Run(() =>
            //{
            //    while (!ct.IsCancellationRequested)  
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine("线程{0}:创建了Task任务", Thread.CurrentThread.ManagedThreadId);
            //    }
            //}, ct.Token);

            //Thread.Sleep(5000);
            //取消任务
            //ct.Cancel();
            //延时取消
            //ct.CancelAfter(5000);
            #endregion


            //Console.WriteLine("线程{0}:,执行到最后了", Thread.CurrentThread.ManagedThreadId);

            #endregion


            #region async await的使用

            //MyMethod();

            //Console.WriteLine($"程序最后的一句话,线程id：{Thread.CurrentThread.ManagedThreadId},序号：5");

            //需求：让MyMethod方法中所有的代码都执行完毕之后，我才能继续执行下面的代码。
            //Task task = MyMethod();
            //Console.WriteLine($"程序倒数第二句话,线程id：{Thread.CurrentThread.ManagedThreadId},序号：4");

            //task.Wait();
            //Console.WriteLine($"程序最后的一句话,线程id：{Thread.CurrentThread.ManagedThreadId},序号：5");

            #region 异步方法
            //异步方法的特点就是主线程遇到await的时候就出去异步方法了，继续执行异步方法以外的代码
            //MyMethod2();

            //Console.WriteLine($"程序最后的一句话,线程id：{Thread.CurrentThread.ManagedThreadId},序号：5");

            //需求：让MyMethod2方法中所有的代码都执行完毕之后，我才能继续执行下面的代码。
            Task task = MyMethod2();
            //task.Wait();
            Console.WriteLine($"程序最后的一句话,线程id：{Thread.CurrentThread.ManagedThreadId},序号：5");
            #endregion


            #endregion

            Console.ReadLine();
        }

        //public static void MyMethod()
        //{
        //    Console.WriteLine($"方法中的Task之前的代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：1");

        //    Task.Run(() =>
        //    {
        //        Console.WriteLine($"方法中的Task代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：2");
        //    });

        //    Console.WriteLine($"方法中的Task之后的代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：3");

        //}

        /// <summary>
        /// 优化后方法，返回Task
        /// </summary>
        /// <returns></returns>
        public static Task MyMethod()
        {
            Console.WriteLine($"方法中的Task之前的代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：1");

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"方法中的Task代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：2");
            });

            Console.WriteLine($"方法中的Task之后的代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：3");

            return task;
        }
        
        /// <summary>
        /// 异步方法，不用返回Task，只要我们用了await它会返回一个Task
        /// </summary>
        /// <returns></returns>
        public static async Task MyMethod2()
        {
            Console.WriteLine($"方法中的Task之前的代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：1");

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"方法中的Task代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：2");
            });

            //...................10000

            Console.WriteLine($"方法中的Task之后的代码,线程id：{Thread.CurrentThread.ManagedThreadId},序号：3");

        }
    }
}
