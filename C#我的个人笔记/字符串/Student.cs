using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串
{
    public class Student
    {
        public string Name { get; set; }


        public override bool Equals(object obj)
        {
            if (this.Name == ((Student)obj).Name)
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
