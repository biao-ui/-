using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public abstract class MyAbstractClass
    {
        public string Id { get; set; }
        public int _age;

        public abstract void MyMethod();

        public void MyMethod2() 
        {
        
        }
    }
}
