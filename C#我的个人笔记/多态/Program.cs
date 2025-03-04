using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    class Program
    {
        static void Main(string[] args)
        {

            Student student =   new Student();
            People p = student;
            p.i = 100;
            Console.WriteLine(student.i + "" + p.i) ;

            //一、继承
            //继承是面向对象程序设计中最重要的概念之一。继承允许我们根据一个类来定义另一个类，这使得创建和维护应用程序变得更容易。同时也有利于重用代码和节省开发时间。
            //一个类可以间接派生自多个类或接口，这意味着它可以从多个基类或接口继承数据和函数。

            //多继承
            //一个类只能直接继承一个类，但是可以间接继承多个类

            //问题：在类里面，普通成员与静态成员有什么区别？
            //问题：子类可以使用父类的成员吗？


            //问题：子类创建对象的时候父类做了什么事情？
            //父类也创建对象，而且比子类优先创建
            //问题：如果父类没有默认的构造函数怎么办？
            //那我需要用到子类就必须手动去调用父类的构造函数。
            #region 测试
            //Student student = new Student();
            //student.Test();
            #endregion

            //二、抽象类
            //C#抽象类是特殊的类，只是不能被实例化；除此以外，具有类的其他特性；
            //重要的是抽象类可以包括抽象方法，这是普通类所不能的。抽象方法只能声明于抽象类中，且不包含任何实现，派生类必须覆盖它们。
            //另外，抽象类可以派生自一个抽象类，可以覆盖基类的抽象方法也可以不覆盖，如果不覆盖，则其派生类必须覆盖它们。
            //abstract 修饰符指示被修改内容的实现已丢失或不完整。
            //abstract 修饰符可用于类、方法、属性、索引和事件。
            //抽象类常用于作其他类的基类，而不用于自行进行实例化。

            //三、接口
            //接口本身并不实现任何功能，它只是和声明实现该接口的对象订立一个必须实现哪些行为的契约。
            //接口不能实例化。

            //问题1：接口和抽象类有什么相同和不同
            //问题2：virtual 和 override 什么时候用？



            //四、多态
            //接口类型或父类类型接收子类的实例，当实例不同时，调用名字相同的方法，实现了不同的功能。
            //测试：举例说明
            #region 测试
            Animal people = new People();
            ////当调用的方法上不写override,也不写new，调用的就是当前类型里面方法。
            ////当调用的方法上写override，调用的就是对象（实例）里面的方法。
            ////当调用的方法上写new，调用的就是当前类型里面方法。
            people.MyMethod2();

            //IPhoneProduct phoneProduct = new HuaweiPhone();
            //phoneProduct.Call();
            #endregion

            Console.ReadKey();
        }
    }
}
