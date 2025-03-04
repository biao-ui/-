using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 结构
{
    public struct MyStruct: Interface1
    {
        public MyStruct(string name) 
        {
            _age = 18;
            _name = name;
        }

        private int _age;

        public int Age {
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

        public void SayHello() 
        {
        
        }
    }
}
