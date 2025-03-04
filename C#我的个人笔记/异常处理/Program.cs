using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 异常处理
{
    class Program
    {
        static void Main(string[] args)
        {
            //异常处理
            //异常是在程序执行期间出现的问题。C# 中的异常是对程序运行时出现的特殊情况的一种响应(报错)

            //string str = null;
            //int i = str.Length;

            //Console.WriteLine("我会被执行吗");

            //try：一个 try 代码块标记着一段有可能发生异常的地方
            //catch：try代码块中出现异常后会进入catch代码块
            //finally：finally 代码块无论是否发生异常都会执行此块中的代码。
            //throw：当问题出现时，程序抛出一个异常。
            //如果使用 throw 会把异常继续往外面抛出，那等于try catch外面的代码报错了

            //模拟一些常见的异常与处理情况
            //try
            //{
            //    string str = null;
            //    //string str = "abc";
            //    int i = str.Length;


            //    //......
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("出错了");
            //    throw;
            //}

            try
            {
                //封装了一个方法
                Test.Method();
            }
            catch (Exception e)
            {

                //throw;
            }

           

            //Console.WriteLine("hahaha");

            Console.WriteLine("我会被执行吗");
        }
    }
}
