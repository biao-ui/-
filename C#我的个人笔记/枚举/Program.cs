using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 枚举
{
    class Program
    {
        static void Main(string[] args)
        {

            //枚举
            //枚举是一组命名整型常量, 所以说枚举是值类型。枚举类型是使用 enum 关键字声明的。一般用于分类是使用。

            //int i = 7;
            //MyEnum e = MyEnum.服饰;

            //题目：如何获取枚举中的值
            //int a = (int)MyEnum.文具;
            //Array arr = Enum.GetValues(typeof(SexEnum));
            //foreach (var item in arr)
            //{
            //    int i = (int)item;
            //    Console.WriteLine(i);
            //}
            //题目：如何获取枚举中字符串
            string str = MyEnum.文具.ToString();

            //题目：如何获取枚举中所以的值与字符串(下拉选)
            string[] strArr = Enum.GetNames(typeof(MyEnum));
            var arr = Enum.GetValues(typeof(SexEnum));
            foreach (var item in arr)
            {
                //值，整数
                int i = (int)item;
                Console.WriteLine("值是：" + i);
                //名字
                string s = item.ToString();
                Console.WriteLine("名字是：" + s);
            }

            //使用场景
            //Student student = new Student();
            //student.Name = "张三";
            //student.Age = 18;
            //student.Sex = SexEnum.男;

            //Student student2 = new Student();
            //student.Name = "李四";
            //student.Age = 28;
            //student.Sex = SexEnum.女;
        }
    }


}
