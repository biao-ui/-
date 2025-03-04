using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            //需求1：定义一个方法，要求传入一个int类型的参数，并且在方法中把传入的参数类型与值都在控制台中打印出来。
            //需求2：定义一个方法，要求传入一个string类型的参数，并且在方法中把传入的参数类型与值都在控制台中打印出来。
            //需求3：定义一个方法，要求传入一个DateTime类型的参数，并且在方法中把传入的参数类型与值都在控制台中打印出来。
            //CommonMethod.ShowInt(100);
            //CommonMethod.ShowString("zs");
            //CommonMethod.ShowDateTime(DateTime.Now);


            //问题：有没有一个通用的方法，代替上面的多个方法？
            //CommonMethod.ShowObject(100);
            //CommonMethod.ShowObject("zs");
            //CommonMethod.ShowObject(DateTime.Now);

            //问题：使用父类object类型作为参数，会带来什么问题么？
            //小问题：使用object来接收其他类型的时候，做隐式转换。性能的效果

            //问题：既然object作为参数有性能的消耗，那可以用什么解决方案代替呢？

            //泛型
            //泛型是允许延迟编写在类或方法中参数的数据类型，直到实际在程序中使用它的时候才会确定真正的类型。
            //定义泛型方法后调用泛型方法
            //CommonMethod.ShowGeneric<int>(100);
            //CommonMethod.ShowGeneric<string>("zs");
            //CommonMethod.ShowGeneric<DateTime>(DateTime.Now);

            #region 性能比较
            //使用计时器类Stopwatch，观察object类型作为参数的方法，与原本确定好类型的方法两者运行消耗的时间。

            Stopwatch watch = new Stopwatch();
            watch.Start();//开始
            for (int i = 0; i < 100000000; i++)
            {
                //需要测试的方法
                CommonMethod.ShowObject(100);
            }
            watch.Stop();//停止
            var objectSecond = watch.ElapsedMilliseconds;
            Console.WriteLine("objectSecond:" + objectSecond);

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();//开始
            for (int i = 0; i < 100000000; i++)
            {
                //需要测试的方法
                CommonMethod.ShowGeneric(100);
            }
            watch2.Stop();//停止
            var genericSecond = watch2.ElapsedMilliseconds;
            Console.WriteLine("genericSecond:" + genericSecond);

            Stopwatch watch3 = new Stopwatch();
            watch3.Start();//开始
            for (int i = 0; i < 100000000; i++)
            {
                //需要测试的方法
                CommonMethod.ShowInt(100);
            }
            watch3.Stop();//停止
            var commonSecond = watch3.ElapsedMilliseconds;
            Console.WriteLine("commonSecond:" + commonSecond);
            #endregion

            //泛型类
            //尝试定义一个泛型类，并且创建该类的对象。
            MyClass<CommonMethod> myClass =  new MyClass<CommonMethod>();

            //泛型约束
            //当泛型的数据类型需要加上一些规则时，可以使用泛型约束来控制泛型的数据类型。
            //struct：泛型类型必须是一个“值类型”
            //class:泛型类型必须是一个“引用类型”
            //new():泛型类型必须有一个无参数的构造函数
            //明确的数据类型，比如Student。泛型类型必须Student或者是Student子类
            //明确的接口类型，比如MyInterface。泛型类型必须MyInterface接口类型，或者是实现了MyInterface接口类型

        }



    }
}
