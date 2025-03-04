using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据类型
{
    class Program
    {
        static void Main(string[] args)
        {
            //一、值类型
            //bool    布尔值 True 或 False 默认值：False

            //char    16 位 Unicode 字符 U +0000 到 U +ffff   默认值：'\0'

            //decimal 128 位精确的十进制值小数类型，28 - 29 有效位数(-7.9 x 1028 到 7.9 x 1028) / 100 到 28   默认值：0.0M

            //float   32 位单精度浮点型 - 3.4 x 1038 到 + 3.4 x 1038  默认值：0.0F
            //double  64 位双精度浮点型(+/ -)5.0 x 10 - 324 到(+/ -)1.7 x 10308    默认值：0.0D

            //byte    8 位无符号整数    0 到 255 默认值：0
            //short   16 位有符号整数类型 - 32,768 到 32,767    默认值：0
            //int     32 位有符号整数类型 - 2,147,483,648 到 2,147,483,647  默认值：0
            //long    64 位有符号整数类型 - 9,223,372,036,854,775,808 到 9,223,372,036,854,775,807  默认值：0L

            //sbyte   8 位有符号整数类型 - 128 到 127  默认值：0
            //uint    32 位无符号整数类型 0 到 4,294,967,295   默认值：0
            //ulong   64 位无符号整数类型 0 到 18,446,744,073,709,551,615  默认值：0
            //ushort  16 位无符号整数类型 0 到 65,535  默认值：0

            //枚举  结构
            #region 测试

            //char c = '张';
            //string s = "zs";

            //float f = 0.1;
            //double d = 0.1;

            //double a = 3000.2, b = 3000.0;
            //double c = a - b;
            //Console.WriteLine(c);
            //Console.ReadKey();
            #endregion

            //二、引用类型
            //常见的引用类型：string、class、object、interface
            //默认值：null
            //题目：画图研究内存怎么分配值类型与引用类型。
            //题目：字符串与字符的有什么区别？
            #region 测试
            //值类型的例子
            //int i = 10;
            //MyClass.MyMethod(i);

            //Console.WriteLine(i);

            //引用类型的例子
            //Student student = new Student();
            //student.Age = 18;
            //MyClass.MyMethod2(student);

            //Console.WriteLine(student.Age);
            //Console.ReadKey();
            #endregion

            //三、类型转换
            //隐式类型转换： 这些转换是 C# 默认的以安全方式进行的转换, 不会导致数据丢失。例如，从小的整数类型转换为大的整数类型，从派生类(子类)转换为基类（父类）。
            //显式类型转换： 显式类型转换，即强制类型转换。显式转换需要强制转换运算符，而且强制转换会造成数据丢失。
            #region 测试

            //int i = 18;
            //long l = i;
            //int i2 = (int)l;

            //string str = "18";
            ////int i = str;
            //object o = str;
            //string str2 = (string)o;

            #endregion
            //类型转换的常用方法
            #region 测试
            //测试parse方法
            string str = "18";
            //转不成功报错
            //int i = int.Parse(str);

            int i;
            //bool b = int.TryParse(str,out i);
            //Console.WriteLine(i);

            //使用我自己写的tryparse
            bool b = IntConvert.TryParse(str, out i);
            //bool b = IntConvert.TryParse2(str, ref i);
            Console.ReadKey();

            //测试Convert
            //Convert.ToInt32();
            #endregion


            //四、变量
            //变量必须先定义后使用，命名规则按照“标识符”规则。变量声明赋值后会在保存在内存中，方便编写代码时读取、修改、赋值等使用。
            //变量的声明
            //int a, b, c;
            //string str;

            //变量赋值使用 “=” 符号。
            //a = 1;
            //b = 2;

            //可以定义变量并赋值
            //int a = 1;
            //int a = 1,b = 2,c = 3;

            //五、常量
            //常量可以被当作常规的变量，只是它们的值在定义后"不能被修改"。
            //定义常量使用 const关键字
            //题目：看下列的代码合法
            //const int i = 1;
            //i = 2;
            #region 测试
            //const int i = 1;
            //i = 2;

            //const int i2;
            //i2 = 1;
            #endregion

            //六、
            //out 参数：必须出方法前必须赋值
            //ref 参数：进入方法前必须赋值
        }

    }
}
