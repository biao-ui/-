using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 结构
{
    public class MyClass
    {

        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {

                //....
                _age = value;
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        static int _index;
        public  static void SayHello()
        {
            int index = _index;
        }
    }
}
