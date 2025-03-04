using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    class Program
    {
        //无参数无返回值的委托
        public delegate void MyDelegate();


        //无参数有返回值的委托
        public delegate string MyDelegate2();
        //有参数有返回值的委托
        public delegate string MyDelegate3(string str);
        //有多个参数有返回值的委托
        public delegate string MyDelegate4(string str, int i);

        static void Main(string[] args)
        {
            //执行业务方法
            //DoSomething();

            //需求1：当我们的业务需要根据不同的情况，DoSomething方法里要调用不同的方法时，应该如何实现呢？
            //如：当条件一时：需要执行MethodClass.Method1，当条件二时：需要执行MethodClass.Method2

            //DoSomething(2);

            //需求2：当业务经常发生改变，如现在又需要加上条件三时：需要需要执行MethodClass.Method3，条件四时。。。。。。等等
            //提问：有没有办法不修改DoSomething方法，让DoSomething方法“专注”做自己的业务呢？
            //DoSomething(MyClass.Method2);

            //委托（Delegate） 是存某个方法的一种引用类型变量。委托特别用于实现事件和回调方法。
            //如何使用委托，优化业务方法？

            //lambda表达式
            // ()=>{} 匿名函数
            //DoSomething(()=> 
            //{
            //    Console.WriteLine("我是Method3方法");
            //    return "我是Method3的返回值";
            //});

            //(string str,int i)=>{}

            //c#中的内置委托
            //Action：没有返回值的委托
            //MyMethod3((int i,string s)=> 
            //{
            //    Console.WriteLine("你好" + i + s);
            //    return true;
            //});
            //Func：有返回值的委托

            #region 测试内置委托

            //Action action = () => { };
            //Action<int> action1 = (int i) => { };
            //Action<int, string, bool> action2 = (int i, string str, bool b) => { };

            //Func<bool> func1 = () => { return false; };
            //Func<int, bool> func2 = (int i) => { return false; };

            ////简写方式，当参数只有一个的时候可以简写参数。当方法体中只有一句话，并且是一句return，可以简写"{}","return",";"
            //Func<int, bool> func3 = i => false;


            #endregion

            #region 多播委托
            MyDelegate myDelegate = MyMethod1;
            myDelegate += MyMethod1;
            myDelegate += MyMethod1;

            myDelegate.Invoke();
            //myDelegate();
            #endregion


            //练习：自己做一个First方法
            //List<int> intList = new List<int>() { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

            //测试：list自己的FirstOrDefault
            //int i1 = intList.FirstOrDefault();
            ////Func<TSource, bool> predicate
            //int i2 = intList.FirstOrDefault((int item) => { return item == 111; });


            #region 自己的First方法
            //测试：自己的做的first方法，要求筛选学生集合
            List<Student> list = new List<Student>()
            {
                new Student()
                {
                    Name = "zs",
                    Age = 18
                },
                new Student()
                {
                    Name = "ls",
                    Age = 28
                },
                new Student()
                {
                    Name = "ww",
                    Age = 38
                }
            };

            //自己的MyFirst方法，筛选学生集合，得到你要想的学生信息
            Student student4 = MyList.MyFirst(list, (Student item) => { return item.Name == "zs"; });
            //不仅能筛选学生集合，还能筛选int集合
            List<int> intList = new List<int>() { 11, 22, 33, 44, 55, 66, 77, 88, 99 };
            int i = MyList.MyFirst(intList, (int item) => { return item == 18; });


            //*************************************拓展方法*******************************
            //可以不修改源码的情况下，给你需要加方法的类加自定义方法。类必须是静态类，拓展方法必须是静态方法，而且第一个参数前面加上this关键字
            //参数的类型是你要拓展类型
            //使用拓展方法实现了myFirst,
            Student student5 = list.MyFirst(item => item.Name == "zs");

            //Student student5 = MyList.MyFirst(list, (Student item) => { return item.Name == "ls"; });
            //Student student6 = MyList.MyFirst(list, (Student item) => { return item.Age == 18; });
            #endregion


        }


        ///// <summary>
        ///// 业务方法
        ///// </summary>
        //public static void DoSomething()
        //{
        //    Console.WriteLine("DoSomething方法开始执行业务");

        //    //调用Method1方法，并且打印方法的返回值
        //     string res = MyClass.Method1();

        //    Console.WriteLine(res);

        //    Console.WriteLine("DoSomething方法结束执行业务");
        //}

        //public static void DoSomething(int i)
        //{
        //    Console.WriteLine("DoSomething方法开始执行业务");

        //    string res = "";
        //    调用Method1方法，并且打印方法的返回值
        //    if (i == 1)
        //    {
        //        res = MyClass.Method1();
        //    }
        //    else if (i == 2)
        //    {
        //        res = MyClass.Method2();
        //    }

        //    Console.WriteLine(res);

        //    Console.WriteLine("DoSomething方法结束执行业务");
        //}

        public static void DoSomething(MyDelegate2 myDelegate)
        {
            Console.WriteLine("DoSomething方法开始执行业务");

            string res = "";

            //调用委托中的方法
            res = myDelegate();

            Console.WriteLine(res);

            Console.WriteLine("DoSomething方法结束执行业务");
        }

        /// <summary>
        /// 没有参数没有返回值的方法
        /// </summary>
        public static void MyMethod1()
        {
            Console.WriteLine("我是MyMethod1");
        }

        /// <summary>
        /// 没有参数没有返回值的方法
        /// </summary>
        public static void MyMethod2()
        {
            Console.WriteLine("我是MyMethod2");
        }


        /// <summary>
        /// 测试内置委托  Action<int,int,string>
        /// </summary>
        public static void MyMethod3(Func<int, string, bool> func)
        {

            //执行委托，调用委托里面的方法
            bool i = func(100, "zs");
            Console.WriteLine(i);
        }
    }
}
