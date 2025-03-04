using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public class Student : People
    {
        public new int i;

        public int Number { get; set; }
        public new string Name { get; set; } = "student";

        //public Student(string name) : base(name)
        //{
        
        //}

        public void Test()
        {
            Console.WriteLine(base.Name);
            Console.WriteLine(this.Name);
        }
    }
}
