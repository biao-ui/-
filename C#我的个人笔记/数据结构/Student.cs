using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            Student student =(Student)obj;
            if (this.Name == student.Name && this.Age == student.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
