using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 常量_静态_只读
{
    class Program
    {
        public string Name { get; set; }
        int age = 18;

        static void Main(string[] args)
        {
            //一、静态成员
            //1、通过static关键字修饰，是属于类，实例成员属于对象，在这个类第一次加载的时候，这个类下面的所有静态成员会被加载。
            //2、静态成员只被创建一次，所以静态成员只有一份，实例成员有多少个对象，就有多少份。
            //3、类加载的时候，所有的静态成员就会被创建在“静态存储区”里面，一旦创建直到程序退出，才会被回收。
            //4、变量需要被共享的时候，方法需要被反复调用的时候，就可以把这些成员定义为静态成员。
            //5、在静态方法中，不能直接调用实例成员，因为静态方法被调用的时候，对象还有可能不存在。
            //6、this / base 关键字在静态方法中不能使用，因为有可能对象还不存在。
            //7、在实例方法中，可以调用静态成员，因为这个时候静态成员肯定存在。

            //二、静态成员和实例成员的区别
            //1、生命周期不一样。
            //2、在内存中存储的位置不一样。堆--引用类型数据   静态--静态存储区

            //三、静态类
            //1、被static关键字修饰的类。
            //2、静态类里面只能声明静态成员。
            //3、静态类的本质，是一个抽象的密封类，所以不能被继承，也不能被实例化。
            //4、如果一个类下面的所有成员，都需要被共享，那么可以把这个类定义为静态类。

            //四、静态构造函数
            //1、这个类的成员，第一次被访问之前，就会执行静态构造函数。
            //2、静态构造函数只被执行一次。

            #region 测试
            MyStaticClass.MyMethod();
            MyStaticClass.MyMethod();
            #endregion

            //五、readonly只读与const常量的区别
            //const声明变量的时候就要初始化
            //readonly声明可以赋值也可以不赋值，还可以构造函数里赋值。

            Student student = new Student();

            Console.ReadKey();
        }
    }
}
