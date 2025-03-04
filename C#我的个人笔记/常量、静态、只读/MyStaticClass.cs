using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 常量_静态_只读
{
    public class MyStaticClass
    {
        static MyStaticClass() 
        {
            Console.WriteLine("我是静态构造函数的内容");
        }

        public static void MyMethod() 
        {
            Console.WriteLine("我是MyMethod的内容");
        }
    }
}
