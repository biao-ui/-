using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 基础回顾.NewFolder1;
using 基础回顾.NewFolder2;

namespace 基础回顾
{
    class Program
    {
        //程序入口
        static void Main(string[] args)
        {
            //一、标识符
            //标识符是C#程序员为类型、方法、变量、常量等定义的名字，可以由字母、数字、下划线（_）、汉字等组成。
            //注意：标识符要以字母、下划线、汉字开头，不能以数字开头，不能包含空格。“关键字”不能用作标识符。但是可以用@符号作前缀来避免这个问题。

            //题目：看下列的命名是否合法
            //1、abc
            //2、Abc
            //3、aBc
            //4、a1bc
            //5、1abc
            //6、a b c
            //7、class
            //8、_abc
            //9、ab-c
            //10、@class
            #region 测试
            //int ab-c = 1;
            //int class = 1;
            //int @class = 1;
            //int myclass = 1;

            //int abc = 1;
            //int ABC = 2;
            #endregion

            //提问：ABC 和 abc这两个可以同时使用么？

            //二、关键字
            //关键字是C#语言中保留作为专用特定的字符串，不能作为标识符来使用。
            //常见关键字有：class int string if while 等等等。。。。。。

            //三、语句
            //语句是程序中执行操作的一条命令，每条语句都必须以分号结束 。可以在一行中写多条语句，也可以将一条语句写在多行上。
            //注意：每行语句都应该有缩进，这是为了方便查看代码，也是编程的一种习惯。
            #region 测试
            //int i = 1;int a = 2;
            //int i
            //    = 1;
            #endregion

            //四、注释
            //注释是对代码描述和说明的。
            //行注释：//
            //块注释：/*  */
            //文档注释：///


            //五、命名空间
            //命名空间就是类区分一个大分类
            //可以使用using来引用，不同命名空间的其他类型。否则需要写类型的全名称。
            #region 测试

            基础回顾.NewFolder1.Student student = new 基础回顾.NewFolder1.Student();


            #endregion


            Console.WriteLine("hello world");
            Console.ReadLine();
        }
    }
}
