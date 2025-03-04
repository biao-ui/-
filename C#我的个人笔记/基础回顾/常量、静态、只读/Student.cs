using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 常量_静态_只读
{
    public class Student
    {

        public const int Age = 18;

        public static readonly int Sex = 18;
         
        static Student() 
        {
            Sex = 1;
        }

        public void Test()
        {
            //Age = 20;
            //Sex = 20;
        }
    }
}
