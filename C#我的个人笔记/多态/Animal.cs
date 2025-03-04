using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public class Animal : MyAbstractClass, MyInterface, MyInterface2
    {
        public override void MyMethod()
        {
            throw new NotImplementedException();
        }

        public bool MyMethod(string name, int age)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 虚方法
        /// </summary>
        public virtual void MyMethod2()
        {
            Console.WriteLine("Animal的MyMethod2");
        }


    }
}
