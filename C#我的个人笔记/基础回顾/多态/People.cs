using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public class People : Animal
    {
        //public People(string name)
        //{

        //}

        public string Name { get; set; } = "People";

   
        public override void MyMethod2()
        {
            Console.WriteLine("People的MyMethod2");
        }
    }
}
