using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    class CommonMethod : MyClass2, MyInterface
    {
        public CommonMethod(string s) { }

        public static void ShowInt(int iParameter)
        {
            //Console.WriteLine("我是ShowInt方法,类型={0},值={1}", iParameter.GetType().Name, iParameter);
        }

        //public static void ShowString(string iParameter)
        //{
        //    Console.WriteLine("我是ShowInt方法,类型={0},值={1}", iParameter.GetType().Name, iParameter);
        //}

        //public static void ShowDateTime(DateTime iParameter)
        //{
        //    Console.WriteLine("我是ShowInt方法,类型={0},值={1}", iParameter.GetType().Name, iParameter);
        //}

        public static void ShowObject(object iParameter)
        {
            //Console.WriteLine("我是ShowInt方法,类型={0},值={1}", iParameter.GetType().Name, iParameter);
        }

        public static void ShowGeneric<T>(T iParameter)
        {
            //Console.WriteLine("我是ShowInt方法,类型={0},值={1}", iParameter.GetType().Name, iParameter);
        }

    }
}
