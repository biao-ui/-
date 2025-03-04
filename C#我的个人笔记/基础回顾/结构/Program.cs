﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 结构
{
    class Program
    {
        static void Main(string[] args)
        {
            //结构
            //结构可带有方法、字段、索引、属性、运算符方法和事件。
            //结构可定义构造函数，但不能定义析构函数。但是，您不能为结构定义无参构造函数。无参构造函数(默认)是自动定义的，且不能被改变。
            //与类不同，结构不能继承其他的结构或类。
            //结构不能作为其他结构或类的基础结构。
            //结构可实现一个或多个接口。
            //结构成员不能指定为 abstract、virtual 或 protected。
            //当您使用 New 操作符创建一个结构对象时，会调用适当的构造函数来创建结构。与类不同，结构可以不使用 New 操作符即可被实例化。
            //如果不使用 New 操作符，只有在所有的字段都被初始化之后，字段才被赋值，对象才被使用。

            //MyStruct myStruct = new MyStruct();
            //myStruct.Age = 18;
            //MyStruct myStruct2;
            //myStruct2._name = "zs";

            //问题：结构和类有什么不同
            //练习：创建类的对象与创建结构对象对比。
            //MyStruct myStruct = new MyStruct();
            //myStruct.Age = 18;
            //myStruct.Name = "zs";

            //MyStruct myStruct2 = myStruct;

            //myStruct.Age = 20;
            //myStruct.Name = "ls";

            //MyClass myClass = new MyClass();
            //myClass.Age = 18;
            //myClass.Name = "zs";

            //MyClass myClass2 = myClass;

            //myClass.Age = 20;
            //myClass.Name = "ls";
        }
    }
}
