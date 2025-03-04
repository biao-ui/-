using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    class MyClass
    {
        public static string Method1()
        {
            Console.WriteLine("我是Method1方法");
            return "我是Method1的返回值";
        }

        public static string Method2()
        {
            Console.WriteLine("我是Method2方法");
            return "我是Method2的返回值";
        }
    }
}
