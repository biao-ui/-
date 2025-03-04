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
            //异常是在程序执行期间出现的问题。C# 中的异常是对程序运行时出现的特殊情况的一种响应

            //string str = null;
            //int i = str.Length;

            //try：一个 try 代码块标记着一段有可能发生异常的地方
            //catch：try代码块中出现异常后会进入catch代码块
            //finally：finally 代码块无论是否发生异常都会执行此块中的代码。
            //throw：当问题出现时，程序抛出一个异常。使用 throw 关键字来完成。

            //模拟一些常见的异常与处理情况
            //try
            //{
            //    string str = null;
            //    int i = str.Length;

            //    //......
            //}
            //catch (Exception e)
            //{

            //    //throw;
            //}

            Test.Method();

            Console.WriteLine("hahaha");
        

        }
    }
}
