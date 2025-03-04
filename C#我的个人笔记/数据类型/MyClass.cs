using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据类型
{
    public class MyClass
    {
    

        public static void MyMethod(int i)
        {
            Console.WriteLine(i);

            i = i + 100;
            Console.WriteLine(i);
        }

        public static void MyMethod2(Student student)
        {
            Console.WriteLine(student.Age);

            student.Age = student.Age + 10;
            Console.WriteLine(student.Age);
        }


    }
}
